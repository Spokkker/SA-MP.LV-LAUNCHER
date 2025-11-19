# SA-MP.LV Launcher

Vizuāls prototips C# Windows Forms lietotnei **Mystic Launcher**. Šobrīd pieejams tikai interfeiss (kā Arizona Evolve/Pears stila iedvesma), funkcionālie savienojumi un atjauninājumi tiks pievienoti nākamajos posmos.

## Projekta palaišana

1. Atveriet `MysticLauncher.sln` Visual Studio (Windows) vai `MysticLauncher/MysticLauncher.csproj`.
2. Mērķa ietvars: `.NET 8.0 (Windows)` ar `UseWindowsForms` iestatījumu.
3. Palaidiet projektā esošo `MainForm`.

> Šajā repozitorijā nav iekļauta .NET SDK instalācija, tāpēc būvniecības komandas var nebūt pieejamas šeit esošajā vidē.

## Patch piemērošanas padomi

Ja saņemat kļūdu, piemērojot `launcher.patch`, izmēģiniet šos soļus:

1. Pārliecinieties, ka atrodaties šī repozitorija saknē un darba koks ir tīrs (`git status` nerāda izmaiņas).
2. Lejupielādējiet patch failu un palaidiet bez `--3way` karoga: `git apply --whitespace=nowarn launcher.patch`.
   * `--whitespace=nowarn` apklusinās traucējošus brīdinājumus par beigu atstarpēm.
3. Ja iepriekš redzējāt `repository lacks the necessary blob to perform 3-way merge`, iemesls parasti ir tas, ka `--3way` cenšas atrast bāzes revīziju, kas nav pieejama. Izlaidiet šo karogu vai lietojiet `git am launcher.patch` (tas ieliek izmaiņas kā jaunu komitu).
4. Ja README vai citi faili jau ir lokāli mainīti, `git restore README.md` (un citi attiecīgie faili) atjaunos tos pirms patch piemērošanas.

Papildus varat paši ģenerēt patch failu no jaunākā komita, ja strādājat ar šo repozitoriju:

```bash
git format-patch -1 HEAD --output mystic-launcher.patch
```

Tad patch var pārnest uz citu mašīnu un piemērot ar `git am mystic-launcher.patch`.
