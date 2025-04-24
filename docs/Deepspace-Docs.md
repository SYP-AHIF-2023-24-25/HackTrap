# Dokumentation Deepspace

Die Grundsätze des Deepspaces bzw. Unity werden in dem PDF :page_facing_up: [deepspace-dev](./deepspace_dev.pdf) erklärt.

Weiters werden in den nächsten Absätzen nun genauer die von uns implementierten Einzelheiten erläutert:

## StateManager

Grundsätzlich werden in Unity `Scenes` verwendet, da der Deepspace jedoch nur mit einer Scene arbeitet, müssen alle Scenes in `Prefabs` verwandelt und in die Hauptscene `Hacktrap` eingefügt werden.

Der `StateManager` ist eine zentrale Komponente, die Szenenwechsel in Unity organisiert und verwaltet. Anders als der klassische Unity `SceneManager`, der Szenen lädt und entlädt, arbeitet dieser StateManager hauptsächlich mit Prefabs. Diese Prefabs werden zur Laufzeit aktiviert oder deaktiviert.

### Komponenten aus dem Screenshot

Die Komponenten sind 18 unterschiedliche Prefabs, die durch den StateManager verwaltet werden. Einige relevante Beispiele:

- `AnfangsScene` (Einstiegspunkt)
- Diverse Szenen (z.B. `00`, `01`, `PfeilScene`, `TicTacToeCelebration` usw.)
- Szenen zur Beschreibung und Ergebnisauswertung (`DescriptionTrail`, `MainGameResult`, `Success`, `Failure`, `End`, `TrialRunEncryption`)
- Initiale Szene ist auf Index 0 gesetzt - für den Eintrittspunkt bzw. die Anfangsscene

### Funktionsweise des bereitgestellten Skripts

#### Grundlegende Eigenschaften:

- Singleton-Muster (nur eine Instanz des StateManagers).
- Der StateManager wird nicht zerstört (`DontDestroyOnLoad`).
- Alle Szenen-Prefabs sind im Array (`scenePrefabs`) gespeichert.

#### Initialisierung (Start/Awake):

Beim Start werden alle Prefabs deaktiviert, außer der initialen Szene. Wenn auf eine andere Scene übergegangen wird, werden die vorherigen bzw. die vorherige gelöscht und die darauffolgenden sind immer noch deaktiviert.

### Wechseln der Szenen (Prefabs):

- `SwitchSceneAfterDelay`: Szenenwechsel nach Verzögerung.
- `SwitchToScenePrefab`: Sofortiger Wechsel ohne Verzögerung.
- `SwitchToNextScenePrefab`: Zyklisch durch die Szenen.
- `SwitchSceneAfterAnimation`: Nach Animation erfolgt Szenenwechsel.

#### Hilfsmethoden:

`GetCurrentIndex`: Gibt aktuellen Szenenindex zurück.

### Scene Template (für die einzelnen Prefabs)
Es gibt ein `TemplateScenePrefab`, das sich in `All` in der `HackTrap` Scene befindet. In diesem Template befindet sich eine fertige Scene mit Tracking. Eine Scene besteht aus:

- WALL
- FLOOR
- TRACKING

## PlayerTracker

Der `PlayerTracker` verwaltet alle Spieler auf dem Floor. Wenn ein Spieler den Floor betritt, wird dieser an die Liste im PlayerTracker angehängt. Genau so wird er gelöscht, wenn ein Spieler den Boden verlässt.

Den `PlayerTracker` findet man unter der `HackTrap` Scene und dann unter `All`. Es ist also ein zentrales Element in der `HackTrap` Scene und beinhaltet das Script `PlayerCounterController`, welches die Spieler dann verwaltet.

Hier werden die einzelnen Methoden nun genauer beschrieben:

```csharp
private int playerCount = 0;
private List<GameObject> playerObjects = new List<GameObject>();

void OnTriggerStay(Collider other)
{
    if (other.CompareTag("DPlayer") && !playerObjects.Contains(other.gameObject))
    {
        playerObjects.Add(other.gameObject);
        playerCount++;
        AssignPlayerToTeam(other.gameObject);
    }
}
```
Diese Methode wird ständig aufgerufen, solange ein Collider im Trigger-Bereich - also dem Floor - bleibt.

Wenn ein Objekt mit dem Tag `DPlayer` den Boden berührt und noch nicht registriert wurde, wird dieses Objekt:
- der Liste `playerObjects` hinzugefügt.
- der Zähler `playerCount` erhöht.
- per `AssignPlayerToTeam` einem Team zugeordnet.


```csharp
public void InitializeTeamColor(GameObject playerObject)
{
    List<List<GameObject>> teams = GetTeams();
    for (int i = 0; i < teams.Count; i++)
    {
        foreach (GameObject playerObj in teams[i])
        {
            MeshRenderer[] currentMeshRenderers = playerObj.GetComponentsInChildren<MeshRenderer>();
            currentMeshRenderers[1].material.color = teamsColor[i];
        }
    }
}
```
Diese Methode holt sich alle `Teams` (jeweils eine Liste von GameObjects) und weist jedem Spieler die entsprechende Teamfarbe zu, indem es den zweiten `MeshRenderer` ([1]) einfärbt.


```csharp
public void AssignPlayerToTeam(GameObject playerObject)
{
    var smallestTeam = teams.OrderBy(team => team.Value.Count).First();
    var smallestTeamList = smallestTeam.Value;
    smallestTeamList.Add(playerObject);

    Player player = playerObject.GetComponent<Player>();
    player.team = (Player.Team)Enum.Parse(typeof(Player.Team), smallestTeam.Key);
    players.Add(player);

    InitializeTeamColor(playerObject);
}
```
Diese Methode sucht das Team mit den wenigsten Spielern und fügt den neuen Spieler diesem Team hinzu.

Zusätzlich holt diese Methode sich das `Player-Script` des Objekts und weist dem Spieler sein Team zu (`Player` Klasse bzw. Script - ist auf jedem einzelnen Spieler drauf).
Danach wird der Spieler zur `players`-Liste hinzugefügt.

Am Schluss muss noch `InitializeTeamColor()` aufgerufen werden, um diesem Spieler die Farbe in dieser Scene zuzuweisen.

## Pharus
### Was ist Pharus?
`Pharus` ist eine Softwarelösung, die Tracking-Daten in Echtzeit verarbeitet und an Unity überträgt. Dabei können Personen oder Objekte über Sensoren (z.B. Laser-Tracking oder TUIO-basierte Systeme) erkannt und ihre Positionen kontinuierlich aktualisiert werden.

Die Komponenten von Pharus sind folgende:
- `TuioReceiveHandler`
- `TracklinkReceiveHandler`
- `TrackingEntityManager`
- `TrackParent`

### Erklärung und Aufgaben der Skripte

#### 1. UdpReceiver (Teil von DeepSpace.Udp)

Zweck des UdpReceivers ist es `UDP-Netzwerkpakete` zu empfangen und diese zu verarbeiten.

Er öffnet einen `UDP-Socket`, der Nachrichten über das Netzwerk empfängt und prüft eingehende Nachrichten auf Gültigkeit und leitet die Daten an abonnierte Methoden weiter.

Die Kernfunktionalität liegt darin, den UDP-Port zu öffnen und zu binden.

Außerdem verarbeitet er eingehende Nachrichten (Bytes) und informiert alle registrierten Event-Handler (z.B. `TracklinkReceiveHandler`).

#### 2. TracklinkReceiveHandler

TracklinkReceiveHandler dient dem `Empfang` und der `Verarbeitung` von Tracking-Informationen, die über `UDP-Nachrichten` übermittelt werden.

Seine Hauptaufgabe besteht darin, eingehende UDP-Datenpakete zu empfangen und daraus relevante Track-Informationen wie Position, Orientierung, Geschwindigkeit sowie Echo-Daten auszulesen. Diese Informationen werden anschließend genutzt, um sogenannte `Track-Objekte` (vom Typ `TrackRecord`) zu erstellen und fortlaufend zu verwalten.

Im Hintergrund pflegt dieses Modul eine interne Liste (`_trackDict`), in der alle aktuell aktiven Tracks gespeichert sind. Sobald neue oder aktualisierte Track-Daten vorliegen, informiert weck automatisch alle registrierten Empfänger, die das Interface `ITrackingReceiver` implementieren.

Die Kernfunktionalität liegt somit in der `Umwandlung von Rohdaten in verwertbare Tracking-Daten`, in der strukturierten Verwaltung dieser Informationen sowie in der reaktiven Kommunikation mit anderen Systemkomponenten, die auf diese Tracking-Daten angewiesen sind.

#### 3. TuioReceiveHandler

Der `TuioReceiveHandler` ist verantwortlich für den Empfang und die Verarbeitung von Tracking-Daten, die auf dem TUIO-Protokoll basieren.  

`TUIO` (Tangible User Interface Objects) ist ein Netzwerkprotokoll, das speziell für die Übertragung von Touch- und Bewegungsinformationen entwickelt wurde. Der Handler lauscht auf eingehende TUIO-Nachrichten und wandelt diese in verwertbare Track-Daten um.

Im Mittelpunkt seiner Aufgaben steht die Verwaltung von Tracks, die aus Cursor-Events generiert werden. Darüber hinaus behandelt der Handler sogenannte `Echos` als eigenständige TUIO-Objekte und verarbeitet sie entsprechend.  

Bei jeder Änderung eines Tracks oder Echo-Objekts benachrichtigt der TuioReceiveHandler alle registrierten Empfänger, die das Interface `ITrackingReceiver` implementieren.  

Die Kernfunktionalität umfasst die Erstellung und kontinuierliche Aktualisierung von `TrackRecord`-Objekten basierend auf den empfangenen TUIO-Daten. Dazu gehört das Management von Positionen, Bewegungen und Echos sowie die Weitergabe aller relevanten Track-Updates an andere Systemkomponenten innerhalb der Unity-Umgebung.

### Zusammenspiel aller Komponenten

- `Pharus`: Erkennt Personen/Objekte, sendet Positionsdaten über UDP an Unity.
- `UdpReceiver`: Empfängt Daten und leitet sie weiter.
- `TracklinkReceiveHandler / TuioReceiveHandler`: Übersetzen Rohdaten zu nutzbaren Informationen, verwalten Tracks.
- `TrackingEntityManager / TrackParent`: Verwalten Track-GameObjects (Positionen, Animationen etc.).

### Typischer Ablauf (zusammenfassend)

- Pharus erkennt Person/Objekt, sendet Tracking-Daten (UDP).
- Unitys UdpReceiver empfängt diese Daten.
- TracklinkReceiveHandler oder TuioReceiveHandler übersetzen Rohdaten.
- Track-Daten werden gespeichert und weitergegeben.
- TrackingEntityManager/TrackParent aktualisiert GameObjects in Unity.

## Verbindung zwischen Wall und Floor

## Main-Game (Viren-Einfangen-Spiel)
Im `Main-Game` treten zwei Teams gegeneinander an, um möglichst viele Viren in ihr jeweiliges Teamfeld zu bringen. Jeder Spieler kann maximal 4 Viren gleichzeitig sammeln und muss anschließend zurück zum Teamfeld, um diese dort abzuladen. Das Team, das am Ende die meisten Viren gesammelt hat, qualifiziert sich für das Encrypt-Game.

## Encrypt-Game (Anagramm-Lösen-Spiel)
Im `Encrypt-Game` werden Buchstaben in zufälliger Reihenfolge auf dem Boden angezeigt. Der Spieler muss diese Buchstaben durch Betreten in die korrekte Reihenfolge bringen. Ist ein Buchstabe richtig gewählt, erscheint dieser an der Wand. Ist die Wahl falsch, ertönt ein akustisches Signal.

## Build für Deepspace verschicken

Um einen Build zu verschicken, muss man zunächst in Unity in der Taskleiste auf `File > Build Settings` gehen und dann die jeweilige Hauptscene auswählen (in unserem Fall `Hacktrap`).

![Build](images/Build.png)

Danach muss man nur noch auf `Build` drücken und den Build in einen Ordner speichern.
