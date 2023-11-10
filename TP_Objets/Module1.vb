Module Module1

    Sub Main()

        'Bonnes pratiques:
        'SOLID: est l'acronyme de 5 principes à appliquer dans la conception objet
        'S: Single of responsability - une classe ne doit gérer qu'une seule et unique tâche
        'O: open/close - une classe doit petre ouverte à l'extension mais fermée à la modif (polymorphisme)
        'L: Liskov Subtitution: les objets enfants doivent être substituables aux parents
        ' Si A se comporte comme B
        '  Alors A hérite de B
        'I: Interface Segregation - Découper les interfaces complèxes en interfaces orientées métier- interafce qui
        'ne gère qu'un seul et unique besoin métier
        'D: Dependecy Inversion / Dependency Injection

        'Tell D'ont Ask: dites, ne posez pas de questions. Dites à vos objets ce qu'ils doivent faire,
        ' ne leur posez pas de questions sur leur état
    End Sub

End Module
