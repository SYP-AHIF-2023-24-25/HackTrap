# Dokumentation Deepspace

Die Grundsätze des Deepspaces bzw. Unity werden in dem PDF :page_facing_up: [deepspace-dev](./deepspace_dev.pdf) erklärt.

Weiters werden in den nächsten Absätzen nun genauer die von uns implementierten Einzelheiten erläutert:

## StateManager

Grundsätzlich werden in Unity `Scenes` verwendet, da der Deepspace jedoch nur mit einer Scene arbeitet, müssen alle Scenes in `Prefabs` verwandelt und in die Hauptscene `Hacktrap` eingefügt werden.

### Scene Template (für die einzelnen Prefabs)

TODO

Der `StateManager` hilft dann dabei von einer Scene bzw. einem Prefab zum nächsten überzugehen.

Der `StateManager` sieht wie folgt aus:

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

## Verbindung zwischen Wall und Floor


## Main-Game (Viren-Einfangen-Spiel)

## Encrypt-Game (Anagramm-Lösen-Spiel)

## Build für Deepspace verschicken

Um einen Build zu verschicken, muss man zunächst in Unity in der Taskleiste auf `File > Build Settings` gehen und dann die jeweilige Hauptscene auswählen (in unserem Fall `Hacktrap`).

![Build](images/Build.png)

Danach muss man nur noch auf `Build` drücken und den Build in einen Ordner speichern.
