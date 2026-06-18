# LinqBasics — UFO Sightings Dataset

Et konsolprogram skrevet i C# som leser inn et CSV-datasett, mapper radene til C#-objekter, og lar brukeren kjøre LINQ-spørringer via en interaktiv meny i terminalen.

---

## Datasett

**NUFORC UFO Sightings** — hentet fra Kaggle  
Fil brukt: `Data/scrubbed.csv`  
Kilde: <https://www.kaggle.com/code/rtatman/fun-beginner-friendly-datasets>

Datasettet inneholder over 80 000 rapporterte UFO-observasjoner med felter som by, land, form, varighet og koordinater.

---

## Hvordan kjøre programmet

**Krav:** .NET 9 SDK installert

```bash
git clone https://github.com/Lindgard/LinqBasics.git
cd LinqBasics
dotnet run
```

Programmet laster inn CSV-filen automatisk og viser en meny i terminalen.

---

## Programflyt (skisse)

```txt
Start
  └─> Program.cs oppretter UfoController
        └─> UfoController oppretter CsvReader
              └─> CsvReader leser Data/scrubbed.csv med File.ReadAllLines()
                    └─> Hver rad splittes med .Split(',') → Sighting-objekt
              └─> Returnerer List<Sighting> til UfoController
        └─> UfoController sender listen til LinqService
              └─> LinqService utfører LINQ-spørringer på listen
        └─> UfoController viser interaktiv meny i terminalen
              └─> Bruker velger spørring → resultat skrives ut
Slutt
```

---

## Pseudokode

```txt
LES alle linjer fra CSV-filen
HOPP OVER første linje (header)
FOR HVER linje:
    SPLITT på komma → kolonner[]
    HVIS kolonner.Length != 11: HOPP OVER
    OPPRETT nytt Sighting-objekt med verdier fra kolonner
    LEGG TIL i liste

RETURNER liste med Sighting-objekter

VIS meny til bruker
MENS bruker ikke velger "Avslutt":
    LES input
    UTFØR tilhørende LINQ-spørring
    SKRIV UT resultat
    VIS meny igjen
```

---

## Mappestruktur

```txt
LinqBasics/
├── Controllers/
│   └── UfoController.cs     # Mottar input, styrer spørringer og output
├── Data/
│   ├── scrubbed.csv         # Datasett (brukes av programmet)
│   └── complete.csv         # Alternativt datasett (ikke i bruk)
├── Models/
│   └── Sighting.cs          # Representerer én rad i CSV-filen
├── Services/
│   └── LinqService.cs       # Alle LINQ-spørringer samlet her
├── Views/
│   └── CsvReader.cs         # Leser og parser CSV-filen
├── Program.cs               # Inngangspunkt – starter UfoController
└── be_linqBasics.csproj
```

---

## LINQ-spørringer

### Obligatoriske krav

**`Select()` — henter én property fra alle objekter**

```csharp
// LinqService.cs
public IEnumerable<string> GetAllCities()
{
    return _sightings.Select(s => s.City);
}

```

Henter bynavnet fra hvert Sighting-objekt i listen.

---

**`Where()` — filtrerer listen basert på et kriterium**

```csharp
// LinqService.cs
public IEnumerable<Sighting> GetUsSightings()
{
    return _sightings.Where(s => s.Country.ToLower() == "us");
}
```

Returnerer kun observasjoner rapportert fra USA.

---

### Utvidede spørringer

**`OrderByDescending()` — sorterer listen**

```csharp
public IEnumerable<Sighting> GetSortedByDuration()
{
    return _sightings.OrderByDescending(s => s.DurationSeconds);
}
```

Sorterer observasjoner etter varighet, lengst først.

---

**`GroupBy()` — grupperer data**

```csharp
public IEnumerable<IGrouping<string, Sighting>> GetGroupedByShape()
{
    return _sightings.GroupBy(s => s.Shape);
}
```

Grupperer alle observasjoner etter rapportert UFO-form og teller antall per gruppe.

---

**`Distinct()` — unike verdier**

```csharp
public IEnumerable<string> GetDistinctShapes()
{
    return _sightings.Select(s => s.Shape).Distinct();
}
```

Returnerer en liste med unike UFO-former uten duplikater.

---

## Teknisk oversikt

| Klasse | Ansvar |
| --- | --- |
| `CsvReader` | Leser `scrubbed.csv` med `File.ReadAllLines()`, parser hver rad til et `Sighting`-objekt via `.Split(',')` |
| `Sighting` | Modell — representerer én rad i datasettet (by, land, form, varighet, koordinater osv.) |
| `LinqService` | Inneholder alle LINQ-spørringer som metoder, opererer på `List<Sighting>` |
| `UfoController` | Orkestrerer flyten: initialiserer reader og service, håndterer brukerinput og skriver ut resultater |
| `Program` | Enkel inngangspunkt — oppretter `UfoController` og kaller `Run()` |

---

## Refleksjon

- **Modularisering:** Programmet er delt opp slik at hver klasse har ett ansvarsområde. `CsvReader` håndterer kun fillesing, `LinqService` kun spørringer, og `UfoController` kun flytstyring.
- **System.IO:** `File.ReadAllLines()` brukes i `CsvReader` for å lese hele filen inn som en string-array.
- **Parsing:** `.Split(',')` konverterer hver tekstlinje til en kolonnearray som deretter mappes til properties i `Sighting`-klassen med `double.TryParse()` for numeriske felt.
- **LINQ:** Programmet bruker `Select`, `Where`, `OrderByDescending`, `GroupBy` og `Distinct` — alle tilgjengelige via menyen i terminalen.
