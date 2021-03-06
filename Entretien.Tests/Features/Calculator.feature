# language: fr
Fonctionnalité: Planifier un entretien de recrutement chez Soat

    Scénario: Recruteur peut tester le candidat
        Etant donné un candidat ".NET" ("candidat@email.com") avec "2" ans d’expériences qui est disponible "15/04/2019" à "15:00"
        Et qu'un recruteur ".NET" ("recruteur@soat.fr") qui a "6" ans d’XP qui est dispo "15/04/2019" à "15:00"
        Quand on tente une planification d’entretien
        Alors L’entretien est sauvegardé
        Et un mail de confirmation est envoyé au candidat et le recruteur

    Scénario: Recruteur ne peut pas tester le candidat candidat pas disponible
        Etant donné un candidat ".NET" ("candidat@email.com") avec "2" ans d’expériences qui est disponible "15/04/2019" à "15:00"
        Et qu'un recruteur ".NET" ("recruteur@soat.fr") qui a "5" ans d’XP qui est dispo "17/04/2019" à "15:00"
        Quand on tente une planification d’entretien
        Alors L’entretien n est pas sauvegardé

    Scénario: Recruteur ne peut pas tester le candidat candidat a plus d experience
        Etant donné un candidat ".NET" ("candidat@email.com") avec "7" ans d’expériences qui est disponible "15/04/2019" à "15:00"
        Et qu'un recruteur ".NET" ("recruteur@soat.fr") qui a "5" ans d’XP qui est dispo "15/04/2019" à "15:00"
        Quand on tente une planification d’entretien
        Alors L’entretien n est pas sauvegardé

     Scénario: Recruteur ne peut pas tester le candidat candidat a plus d experience et pas disponible
        Etant donné un candidat ".NET" ("candidat@email.com") avec "7" ans d’expériences qui est disponible "15/04/2019" à "15:00"
        Et qu'un recruteur ".NET" ("recruteur@soat.fr") qui a "5" ans d’XP qui est dispo "17/04/2019" à "15:00"
        Quand on tente une planification d’entretien
        Alors L’entretien n est pas sauvegardé




