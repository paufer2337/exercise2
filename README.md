# exercise2
=== C# Övning 2 - Loopar & Strängmanipulation ===
___________________________________________________________


- Hur är programmets struktur uppbyggd?

Svar: Program (UI + menystruktur med huvudmeny och undermeny för biljetter)


===========================================================


- Vilka funktioner/metoder innehåller programmet?

Svar:

~ Huvudmeny:
    Main            = Startar programmet och hanterar huvudmeny i loop
    TicketMenu      = Undermeny för biljettval (single/group)

~ Funktioner:
    CheckPrice      = Räknar ut biljettpris baserat på ålder
    GroupPrice      = Räknar totalpris för grupp + genererar kvitto
    RepeatText10    = Skriver ut användarens text 10 gånger i rad (utan radbrytning)
    GetThirdWord    = Hämtar tredje ordet från en mening

~ Hjälpmetoder:
    ValidAgeInput   = Validerar ålder (0–130)
    ValidGroupSize  = Validerar antal personer i grupp
    CountDownToMenu = Timer innan återgång till meny


===========================================================


- Vad innehåller programmet logiskt?

Svar:

~ Kontrollflöde:
    if / else       = För biljettlogik (barn, ungdom, vuxen, senior)
    switch          = För menyval

~ Loopar:
    while           = Håller menyer igång
    for             = Itererar genom grupp och repetition x10

~ Stränghantering:
    Split()         = Delar upp mening i ord
    Indexering      = Hämtar tredje ordet


===========================================================


- Extra funktionalitet:


~ Input-validering:
    - Hanterar ogiltig input (text istället för siffror)
    - Begränsning av ålder och gruppstorlek
    - Meddelande vid stora grupper (>150 personer)

~ UX/UI:
    - Tydliga menyer
    - Undermeny för bättre struktur
    - Nedräkning vid fel/input
    - Kvitto med sorterade biljettyper


===========================================================


- Hur körs programmet?

cmd:

dotnet run


===========================================================

