# Frosty Targets – 3AHMNS

Unity-Version: **6000.3.24f1**. Projekt: Frosty Targets.

## Projekt öffnen
1. Unity Hub öffnen, **Add project from disk** wählen und diesen Ordner auswählen.
2. Unity **6000.3.24f1** verwenden und den ersten Paketimport abwarten.
3. Szene `Assets/MyGame/Scenes/ShootingScene.unity` öffnen, **Play** drücken.
4. `Assets/MyGame/Scripts/GameManager.cs` und `Target.cs` untersuchen.

## Hinweis bei `UnityEngine.UI` / `Text`-Fehlern
Das Paket **Unity UI (uGUI)** ist unter `Packages/manifest.json` als `com.unity.ugui` eingetragen. Falls trotzdem CS0234 oder CS0246 erscheint: `Window > Package Management > Package Manager` öffnen und unter **In Project** prüfen, ob Unity UI geladen ist. Im Paketmanager **Refresh/Resolve** ausführen; gegebenenfalls Unity schließen und den Ordner `Library` löschen, dann erneut öffnen. Nicht die `using UnityEngine.UI`-Zeile entfernen: sie wird für die vorhandene Punkteanzeige gebraucht.

## Unterricht
Das vorhandene Spawning, der Score und der Sieg bei zehn Treffern sind **Ausgangscode**. Schüler:innen erweitern diese Mechaniken anhand der GitHub-Issues. Der Erstimport ist eine Ausgangsversion; keine Aufgaben sind vorweg implementiert.


## E00 – Ausgangsversion

## Spielablauf:
**Erzeugen:** GameManager.Start() startet mit InvokeRepeating einen timer. Nach 1 Sekunde und dann jede Sekunde wird Spawn() aufgerufen und ein neues Ziel erscheint.
**Anklicken:** Jedes Ziel reagiert in OnMouseDown() auf einen Mausklick. Wird es nicht angeklickt, verschwindet es nach 2 Sekunden von selber
**Punkte:** Bei einem Treffer ruft das Ziel IncrementScore() im GameManager auf. Der Punktestand steigt um 1 und wird oben im Bild angezeigt.
**Spielende:** Bei 10 Punkten erscheint der Text "GEWONNEN" und danach werden keine neuen Ziele mehr erzeugt.

## Aufgaben der Methoden
**GameManager.Start():** Startet das wiederholte Erzeugen der Ziele.
**GameManager.Update():** Stoppt das Erzeugen nach dem Sieg und spielt bei jedem Linksklick das Schuss geräusch ab.
**GameManager.Spawn():** Erzeugt ein Ziel an einer zufälligen Position als Kind von parentOfTargets.
**Target.OnMouseDown():** Meldet den Treffer an den GameManager und zerstört das Ziel

## Bereits vorhandene Funktionen
**Zufallsposition:** x zwischen -365 und 365, y zwischen -202 und 202
**Punkteanzeige:** Der Text oben wird bei jedem Treffer aktualisiert.
**Siegesbedingung:** Ab 10 Treffern erscheint "GEWONNEN" und das Erzeugen endet.
**Schuss Sound:** Jeder Linksklick löst ihn aus, auch bei einem Fehlschuss.

## Wie Target und GameManager zusammenarbeiten
Ziel sucht beim Start den GameManager mit GameObject.Find("GameManager") 
und ruft bei einem Treffer IncrementScore() auf. Destroy(gameObject, 2f) löscht das Ziel dann nach 2 Sekunden

## Geplante Änderungen
Zeitlimit und Game Over, wenn die Zeit abläuft
Schwierigkeitsstufen, z.B. schnelleres Erzeugen oder kürzere Lebensdauer der Ziele
Highscore speichern
