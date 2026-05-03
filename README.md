=== C# Övning 2 - Loopar & Strängmanipulation ===
___________________________________________________________


¤ Hur är programmets struktur uppbyggd?

 - Program (UI + meny med huvudmeny och undermeny för biljetter)

===========================================================


¤ Vilka funktioner/metoder innehåller programmet?


~ Huvudmeny:
|   Main            = Startar programmet och hanterar huvudmeny i loop        |
|   TicketMenu      = Undermeny för biljettval (single/group)                 |

~ Funktioner:
|   CheckPrice      = Räknar ut biljettpris baserat på ålder                  |
|   GroupPrice      = Räknar totalpris för grupp + genererar kvitto           |
|   RepeatText10    = Skriver ut text 10 gånger (utan radbrytning)            |
|   GetThirdWord    = Hämtar tredje ordet från en mening                      |

~ Hjälpmetoder:
|   ValidAgeInput   = Validerar ålder (0–130)                                 |
|   ValidGroupSize  = Validerar antal personer i grupp                        |
|   CountDownToMenu = Timer innan återgång till meny                          |

===========================================================


¤ Vad innehåller programmet logiskt?


~ Kontrollflöde:
|   if / else   = Biljettlogik (barn, ungdom, vuxen, senior)                  |
|   switch      = Hanterar menyval                                            |

~ Loopar:
|   while       = Håller menyer igång                                         |
|   for         = Itererar grupp + repetition x10                             |

~ Stränghantering:
|   Split()     = Delar upp mening i ord                                      |
|   Indexering  = Hämtar tredje ordet                                         |

===========================================================

¤ Extra funktionalitet:


|   Input-validering   = Hanterar felaktig input                              |
|   Begränsningar      = Ålder + gruppstorlek                                 |
|   Stora grupper      = Meddelande vid >150 personer                         |
|   UX/UI              = Undermeny, tydliga flöden, kvitto                    |

===========================================================

cmd:
dotnet run

===========================================================

~ Tack för mig :) ~