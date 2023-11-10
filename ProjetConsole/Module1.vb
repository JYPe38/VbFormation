Imports System.IO
Imports System.Net.Http
Imports System.Reflection
Imports System.Xml.Serialization
Imports ProjetDLL
Imports ProjetDLL.Csharp

Module Module1

    Enum Erreur
        MINEURE = 10
        MAJEURE
        CRITIQUE
    End Enum

    Enum Profil
        ADMIN
        MANAGER
        RH
    End Enum

    Enum Autorisation
        LECTURE
        ECRITURE
        SUPPRESSION
        MODIFICATION
    End Enum

    Class User
        Public Nom As String
        Public Profil As Profil
        Public Autorisations As New List(Of Autorisation)
    End Class

    Structure Salarie
        Public Property Nom As String
        Public Property Prenom As String

        Public Sub New(nom As String, prenom As String)
            Me.Nom = nom
            Me.Prenom = prenom
        End Sub
    End Structure

    'main: le point d'entrée de l'application
    'Conventions de nommage:
    'PascalCase: Classes, méthodes
    'camelCase: variables - maVariable
    'snake_case: ma_variable (utilisée par Python)
    Sub Main()

        'Appel de la méthode aficher du Projet DLL
        Tools.Afficher()
        CsharpTool.Afficher()

#Region "Variable et types de données"

        'Le typage en vb est statique: on doit préciser le type de la variable dès sa déclaration

        'Variable: zone mémoire contenant une valeur typée
        'Types de base (primitifs - valeurs): entiers, réels, chat, boolean
        'Entiers: byte(1 oc), shortv(2 oc), int(4 oc), long(8 oc)
        'Réel: single(4 oc), double(8 oc), decimal(16 oc)
        'Boolean: (1 oc)
        'char: (2 oc)

        Dim myInt As Integer = 10
        Dim x = 10 ' le compilateur détermine le type de la variable selon la valeur qu'on lui a affecté


        'Types complèxes (réferences): string, tableau, enum, classes et objets


        'Conversion de type

        'Conversion implicite: concerne le passage d'un type inf. à un type sup.
        Dim b As Byte = 10
        Dim i As Integer = b

        'Activer le mode strict qui est désactuvé par defaut
        'Clic droit sur le projet - propriétés - compiler - option strict on
        'conversion explicite: concerne le passage d'un type sup. à un type inf.
        'Option1: un CAST: CInt, CBool, CDouble

        Dim b2 As Byte = CByte(i) 'un risque de perte de données
        Dim c As Char = "g"c
        Dim chaine As String = "ceci est une chaine"

        'Option2: utiliser la classe Convert pour les conversions explicites
        Dim s As String = "25"
        Dim i2 As Integer = Convert.ToInt32(s)

        'Fonction IsNumeric:
        If IsNumeric(s) Then
            i = Convert.ToInt32(s)
        End If

        'Fonction Val:
        Dim myDouble As Double = Val("10.5")

        'Fonction CType:
        i = CType("10", Integer)

        'Constante: est une variable dont on ne peut pas modifier la valeur
        Const MA_CONSTANTE As Integer = 10

        'Type nullable:
        'Par définit les types simples(valeur) ne sont pas nullables

        Dim age? As Integer
        Dim age1 As Integer?

        If age.HasValue Then
            Console.WriteLine(age)
        Else
            age = 40
        End If

        age = Nothing



#End Region

#Region "Formattage de chaines"

        Dim ages As Integer = 50
        Dim nom As String = "Marc"

        'Concaténation
        Console.WriteLine("Nom: " & nom & " Age: " & ages)

        'Interpolation:
        'v1:
        Console.WriteLine("Nom: {0} Age: {1}", nom, ages)

        'v2:
        Console.WriteLine($"Nom: {nom} Age: {ages}")

#End Region

#Region "Opérateurs"

        'Opérateurs arithmétiques: +, -, *, /, \ division entière, Mod, ^ (puissace)
        'Opérateurs combinés: +=, -=, *=
        i += 5 ' i = i + 5
        'Opérateurs de comparaison: >, >=, <, <=, =(égalité), <> (différent)
        'Opérateurs logique: And, Or, Xor, Not
        'Is et IsNot (comparer des objets), TypeOf  ..... Is (vérifer le type d'une variable de type complèxe) 
        If TypeOf s Is String Then

        End If

#End Region

#Region "Conditions"

        'if/else
        If myInt > 0 Then
            Console.WriteLine("Positif")
        ElseIf myInt < 0 Then
            Console.WriteLine("Négatif")
        Else
            Console.WriteLine("null")
        End If

        'Select/Case: est une variable du if/else
        Dim number As Integer = 0

        Select Case number
            Case 1 To 5
                Console.WriteLine("Entre 1 et 5")
            Case 6, 7, 8
                Console.WriteLine("entre 6 et 8 inclusif")
            Case 9 To 10
                Console.WriteLine("9 ou 10")
            Case Else
                Console.WriteLine("Non compris entre 1 et 10")
        End Select

        'Opérateur ternaire: IIf(condition, valeur si vraie, valeur si fausse) -
        'permet de faire des affectations conditionnelles
        Dim v = IIf(myInt > 3, 10, 25)


#End Region

#Region "Boucles"

        ' Boucles itératives: 
        '   - For: on doit connaitre le nombre d'itérations
        '   - For Each: permet de parcourir une collection
        ' Boucles conditionnelles:
        '   - While, Do Loop While, Do Loop Until

        Dim myVar As Integer = 1

        'While
        While myVar < 5
            Console.WriteLine($"Passage n°: {myVar}")
            myVar += 1
            If myVar = 3 Then
                Exit While
            End If
        End While

        'Do Loop While

        Do
            Console.WriteLine($"Passage n°: {myVar}")
            myVar += 1
        Loop While myVar < 10 ' fait tant que la condition est vraie

        'Do Loop Until

        Do
            Console.WriteLine($"Passage n°: {myVar}")
            myVar += 1
        Loop Until myVar > 15 ' fait tant que la condition est fausse

        'For
        For index = 1 To 5 'Step 2
            Console.WriteLine($"Passage n°: {index}")
        Next

        'For Each
        Dim t() As Integer = {10, 20, 30}
        For Each element As Integer In t
            Console.WriteLine(element)
        Next

#End Region

#Region "Tableaux"

        'Tableaux statiques
        '1 dimension

        Dim t1(10) As Integer ' 11 cases
        t1(0) = 10

        Dim t2() As Integer = {10, 20, 30}

        ReDim Preserve t2(4)

        '2 dimension
        Dim matrice(,) As Integer = {{3, 4}, {5, 6}}

        'For sur les lignes
        For ligne = 0 To matrice.GetLength(0) - 1

            'For sur les colonnes
            For colonne = 0 To matrice.GetLength(1) - 1
                Console.WriteLine(matrice(ligne, colonne))
            Next

        Next

#End Region

#Region "Enum"

        'Enum est une liste de constantes
        Console.WriteLine("***********Enum*****************")
        Dim e As Erreur = Erreur.CRITIQUE
        Console.WriteLine("Index: " & e)
        Console.WriteLine("Valeur: " & e.ToString())

        Console.WriteLine("Quel est le code de votre erreur (10,11 ou 12)?")
        Dim code As Integer = Convert.ToInt32(Console.ReadLine())

        Dim err As Erreur = CType(code, Erreur)
        Console.WriteLine("Votre erreur est: " & err.ToString())

        Dim u As New User()
        u.Nom = "Jean"
        u.Profil = Profil.ADMIN
        u.Autorisations.Add(Autorisation.LECTURE)
        u.Autorisations.Add(Autorisation.SUPPRESSION)

        If u.Autorisations.Contains(Autorisation.SUPPRESSION) Then
            Console.WriteLine("Suppression OK")
        Else
            Console.WriteLine("Action interdite")
        End If

        'Récupérer toutes les valeurs d'une Enum
        For Each p In [Enum].GetValues(GetType(Profil))
            Console.WriteLine(p)
        Next

#End Region

#Region "Méthodes"

        Console.WriteLine("***********Méthodes***********")

        'Méthode: un ensemble d'instructions réutilisables
        '2 types de méthodes:
        'Procédure: méthode qui ne revoie aucun résultat
        'Fonction: méthode qui renvoie un résultat
        'Syntaxe:
        'Visibilité [Shared] Sub-Function Nom_Fonction(args) as Type_Retour (si fonction)

        'Appel de la méthode d'instance
        Dim m As New MesMethodes()
        m.Afficher()

        'Appel de la méthode de classe
        MesMethodes.Print()
        Dim r = MesMethodes.Somme(10, 20)

        'Appel de la méthode avec des params optionnels:
        MesMethodes.Afficher(100)
        MesMethodes.Afficher(100, 55)

        MesMethodes.Afficher(10, z:=33) 'Appel d'une méthode avec des params nommés (ne tient pas compte de la position des params)

        MesMethodes.PrixTTC(100)
        MesMethodes.PrixTTC(100, tva:=0.3)

        Dim v1 = 15, v2 = 10

        Console.WriteLine($"Avant permutation: v1 = {v1} - v2 = {v2}")

        MesMethodes.Permuter(v1, v2)

        Console.WriteLine($"Après permutation: v1 = {v1} - v2 = {v2}")

        Dim prod = 0
        Dim somme = MesMethodes.Calculs(10, 15, prod)
        Console.WriteLine($"Somme = {somme} - Produit = {prod}")

        MesMethodes.Soustraction(10, 15)
        MesMethodes.Soustraction(10, 15, 20, 25)

        Dim tab() As Integer = {10, 2, 25, 44, 77}
        MesMethodes.Afficher(tab)

        Console.WriteLine("***test des méthodes d'extension:")
        tab.Replace(1, 88)
        tab.AfficherContenu()

        Console.WriteLine($"Somme tab = {MesMethodes.SommeTab(tab)}")
        Console.WriteLine($"Moyenne tab = {MesMethodes.MoyenneTab(tab)}")
        Console.WriteLine($"Min tab = {MesMethodes.MinTab(tab)}")

        Dim st As String = "test"


        'Pour définir des méthodes d'extension:
        '1- Créer un module
        '2- Définir des méthodes d'instance avec en 1er params la classe qu'on souhaite étendre via des méthodes 
        ' voir ExtensionModule du ProjetConsole



#End Region

#Region "Rappels sur les classes"

        Console.WriteLine("******Rappels sur les classes*************")
        '2 styles de programmation:
        'Approche procédurale: repose sur des params et des fonctions
        'Approche objet: repose des classes et des objets

        'Une classe à pour tâche principale de décrire la structure d'un objet, définir une sorte de template à partir
        ' duquel on crée nos objets.
        'Elle contient généralement, 3 choses:
        ' Attributs - Propriétés: représentent l'état de l'objet
        ' Méthodes: représentent le comportemet de l'objet
        ' Constructeur: (New) méthode spéciale qui permet d'instancier la classe en question. Son rôle est d'initialiser tous les
        ' attributs de l'objet

        Dim u1 As Utilisateur = New Utilisateur() 'u1.Nom = Nothing    u1.Age = 0
        Dim u2 As New Utilisateur("DUPONT", 45)

        Console.WriteLine(Utilisateur.Profil)

        Utilisateur.ChangerProfil("RH")

        Console.WriteLine(Utilisateur.Profil)

        Console.WriteLine(u2)



#End Region

#Region "Concepts Objets"

        'Encapsulation - Héritage - Polymorphisme - Abstraction - Association(composition - agrégation)


        'Approche procédurale:

        Dim hauteur = 15
        Dim largeur = 10
        Dim surf = Surface(hauteur, largeur)

        Dim hauteur1 = 15
        Dim largeur1 = 10
        Dim surf1 = Surface(hauteur1, largeur1)

        'Encapsulation:
        'Approche objet:
        '1- Regrouper dans une seule et mm classe tous les params et ttes les fonctions qui concernent le mm sujet
        '2- Pas d'accès publique aux attributs. L'accès passe obligatoirement par les accésseurs (getter/setter)

        Dim rec As New Rectangle()
        rec.Hauteur = -15
        rec.Largeur = 10
        rec.Surface()

        Dim cpt As New CompteBancaire("158ffff", 1500)
        cpt.Depot(1500)
        cpt.Retrait(990)

        If cpt.SoldeInfCinqCent() Then
            Console.WriteLine("notif......")
        End If

        cpt = Nothing

        GC.Collect() ' appel explicite du Garbage Collector, qui ne garantit son passage immédiat

        Dim cpt1 As New CompteBancaire("158ffff", 1500)
        Dim cpt2 As New CompteBancaire("158ffff", 1500)

        Console.WriteLine(cpt1.Equals(cpt2))

        'Héritage

        Dim a As New Animal("animal", 5)
        a.EmettreSon()


        Dim ct As New Chat()
        ct.Nom = "chat"
        ct.Age = 3
        ct.EmettreSon()

        Dim ct2 As New Chat("chat2", 3, "Gris")
        ct2.EmettreSon()

        Dim a1 As Animal = New Animal()
        Dim a2 As Animal = New Chat()
        Dim a3 As Animal = New Chien()

        'Polymorphisme: c'est le fait qu'un objet puisse prendre plusieurs formes.
        'Est une conséquence de l'héritage, c'est le fait que l'objet puisse prendre la forme de tous les objets enfants

        Dim entiers(2) As Integer
        entiers(0) = 10
        entiers(1) = 20

        'Collection polymorphique
        Dim animaux(9) As Animal
        animaux(0) = New Animal()
        animaux(1) = New Chat()
        animaux(2) = New Chien()

        Son(New Animal())
        Son(New Chat())
        Son(New Chien())

        Dim objA As New List(Of A)
        Dim objB As New List(Of B)
        Dim objC As New List(Of C)

        Dim lst As New List(Of MyClasse)
        lst.Add(New D())
        myMethode(New D())

        'Abstraction: une classe abstraite est une classe non instanciable

        Dim hm As Homme = New Homme()
        Dim fm As Femme = New Femme()
        Dim hum As Humain = New Femme()

        Dim clt As New Client("Carrefour", New Adresse(15, "rue de machin 69000 Lyon"))

        Dim dao As IClient = New ClientFichierDAO()
        'dao.Insert(New Client())
        'dao.Delete(New Client())
        'dao.Update(New Client())
        'dao.GetAll()
        Dim aaa As New A()
        If TypeOf aaa Is Archivable Then
            Console.WriteLine("oui")
        End If

#End Region

#Region "Exceptions"

        Console.WriteLine("***********Exceptions************")
        ' Il y'à généralement 3 types d'erreurs:
        ' - erreurs de compilation: détectées par l'IDE
        ' - Exception: une erreur qui provoque l'arrêt de l'application
        ' - Code qui fonctionne mais qui renvoie un résultat inattendu (debug)

        'Exception: pour éviter l'arrêt de l'application, on doit gérer l'exception
        'Pour gérer une exception, on utilise le bloc try/catch
        'Il y'à plusieurs types d'exceptions, chacune porte le nom de l'erreur générée

        Dim valeur As Integer = 10
        Dim tableau() As Integer = {10, 20}

        'Règle: une ressource doit être libérée à la fin de son utilisation: fichier, BD......

        Try
            'Ouvertue d'un fichier lecture/écriture
            'Connexion 
            Console.WriteLine(valeur \ 2)
            Console.WriteLine(tableau(0))
            Dim xx As Integer = 10


        Catch ex As Exception
            Console.WriteLine("Exception gérée.....")
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
            'Catch ex1 As IndexOutOfRangeException
            '    Console.WriteLine("Exception tableau gérée.....")
        Finally
            'Bloc optionnel: exécuté dans tous les cas (exception ou pas)
            'Sert dans la pratique à libérer les ressouces utilisées dans le try: fichier, BD..... 
            Console.WriteLine("Bloc finally.....")
            'Femeture du fichier

        End Try

        Try
            Division(0)
        Catch ex As Exception
            'Remplir un fichier
            'Garder une trace dans une table...
            Console.WriteLine(ex.Message)
        End Try

        'Console.WriteLine("Exit sub......")
        'Console.ReadKey()

        'Exit Sub

        Dim cpte As New CompteBancaire("sdqs158", 1000)
        Try
            cpte.Retrait(5000)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        'Dim cpte2 As CompteBancaire = New CompteBancaire("sdqs", 1000) exception


        Console.WriteLine("suite de l'application......")


#End Region

#Region "String"

        Console.WriteLine("************Classe String*********")
        Dim str As String = "test" ' On peut créer un objet STring sans faire appel au constructeur (via une chaine littérale)

        str = str.ToUpper() ' les objets de types String sont immuables

        Console.WriteLine(str)

        'Quelques fonctions de la classe String:

        Dim phrase = " ceci est une phrase "

        Console.WriteLine("Taille: " & phrase.Length)
        Console.WriteLine("Suppression des éspaces de début et fin de chaine: " & phrase.Trim())
        Console.WriteLine("Phrase contient le ceci? " & phrase.Contains("ceci"))
        Console.WriteLine("Phrase commence par ceci? " & phrase.StartsWith("ceci")) 'false
        Console.WriteLine("Phrase se termine par phrasse ? " & phrase.EndsWith("phrase ")) 'True
        Console.WriteLine("Remplacer une phrase par un paragraphe: " & phrase.Replace("une phrase", "un paragraphe"))
        Console.WriteLine("2 ème char dasn phrase: " & phrase(1)) 'un objet String est un tableau de char
        Console.WriteLine("2 ème char dasn phrase: " & phrase.ElementAt(1))

        'Split: permet de découper une chaine
        Dim chaineCSV = "mot1;mot2 mot3:mot4.mot5"
        Dim mots() As String = chaineCSV.Split(":"c, "."c, ";"c, " "c)
        For Each mt In mots
            Console.WriteLine(mt)
        Next

        'Join: méthode de classe

        Dim result = String.Join(" ", "Il", "est", 17, "h", ":", "01")
        Console.WriteLine(result)

#End Region

#Region "Structure"

        Console.WriteLine("**********Structure************")

        Dim slr As New Salarie("DUPONT", "Jean")
        Dim slr2 As Salarie = slr

        slr2.Nom = "New_Name"
        slr2.Prenom = "New_Prenom"

        Console.WriteLine(slr.Nom)
        Console.WriteLine(slr.Prenom)

        'Constat: slr2 est une copie de slr
        'Structure est un type valeur contraitrement à la classe qui est un type réference
        'Pas d'héritage pour une Structure

#End Region

#Region "Collections"

        Console.WriteLine("***********Collections*******")
        '2 types de collections:
        'Collections faiblement typées

        'Collection ordonnée avec doublons
        Console.WriteLine(">>>>>>>> ArrayList")
        Dim myArray As ArrayList = New ArrayList()
        Console.WriteLine("Taille: " & myArray.Count)

        myArray.Add(10)
        myArray.Add(True)
        myArray.Add("chaine")
        myArray.Add("chaine")

        Console.WriteLine("Array contient 10? " & myArray.Contains(10))
        Console.WriteLine("Index of 10: " & myArray.IndexOf(10)) ' 0

        myArray.Insert(0, 55.1)

        Console.WriteLine("Index of 10 après insert: " & myArray.IndexOf(10)) '1

        'Modifs:
        myArray(1) = 55
        Console.WriteLine("Array contient 10? " & myArray.Contains(10))

        'Suppression de toutes les occurrences de chaine:

        'For Each ob In myArray
        '    If ob.Equals("chaine") Then
        '        myArray.Remove(ob)
        '    End If
        'Next

        'For index = 0 To myArray.Count - 1
        '    If myArray(index).Equals("chaine") Then
        '        myArray.RemoveAt(index)
        '    End If
        'Next

        For index = myArray.Count - 1 To 0 Step -1
            If myArray(index).Equals("chaine") Then
                myArray.RemoveAt(index)
            End If
        Next

        For Each elem In myArray
            Console.WriteLine(elem)
        Next

        'Dim ppp As VariantType = VariantType.String

        'Collections fortement typées
        Console.WriteLine(">>>>>>>> List")
        Dim jours As New List(Of String)

        jours.Add("Samedi")

        'Pile: Stack - Stockage LIFO Last In First Out
        Console.WriteLine(">>>>>>>> Stack: pile")
        Dim pile As New Stack()
        Console.WriteLine("Taille de la pile: " & pile.Count)

        'Ajouts:
        pile.Push("chaine")
        pile.Push(True)
        pile.Push(10)

        'Suppressions:
        pile.Pop() 'Supprime le dernier élément

        For Each el In pile
            Console.WriteLine(el)
        Next

        'Prochain élément à suuprimer:
        Console.WriteLine(pile.Peek()) 'True

        'Queue: file - Stockage FIFO First In First Out
        Console.WriteLine(">>>>>>>> Queue: file")

        Dim myFile As New Queue()
        Console.WriteLine("Taille de la file: " & myFile.Count)

        'Ajouts:
        myFile.Enqueue(10)
        myFile.Enqueue(True)
        myFile.Enqueue("chaine")

        'Suppression

        myFile.Dequeue() ' 

        For Each ele In myFile
            Console.WriteLine(ele)
        Next

        'Prochain à supprimer:

        Console.WriteLine(myFile.Peek()) 'True

        Console.WriteLine(">>>>>>>> Dictionnaire")
        'Dictionnaire: stockage de type clé:valeur
        'Dans un dictionnaire physique le mot est la clé, la valeur est sa définition
        'Dans un dictionnaire les clés sont uniques

        Dim dict As New Dictionary(Of String, String)

        Console.WriteLine("Taille du dict: " & dict.Count)

        'Ajouts:
        dict.Add("serveur", "192.168.1.22")
        dict.Add("port", "8080")
        dict.Add("user", "admin")
        dict.Add("password", "1@@frfrf@@")

        If dict.ContainsKey("serveur") Then
            Console.WriteLine(dict.Item("serveur"))
        Else
            Console.WriteLine("Clé inexistante")
        End If

        'For each sur les clés
        Console.WriteLine(">>> For each sur les clés:")

        For Each cle In dict.Keys
            Console.WriteLine($"Clé: {cle} - Valeur: {dict.Item(cle)}")
        Next

        'For each sur les Valeurs
        Console.WriteLine(">>> For each sur les valeurs:")

        For Each valeur1 In dict.Values
            Console.WriteLine(valeur1)
        Next

        'On peut avoir des dictionnaires complèxes

        Dim dictComptes As New Dictionary(Of String, List(Of CompteBancaire))

        Dim cptCrediteurs As New List(Of CompteBancaire)
        cptCrediteurs.Add(New CompteBancaire("125fff", 2500))
        cptCrediteurs.Add(New CompteBancaire("sqdqsd589", 1236))

        Dim cptDebiteurs As New List(Of CompteBancaire)
        cptDebiteurs.Add(New CompteBancaire("uytr158", -2500))
        cptDebiteurs.Add(New CompteBancaire("sdq789", -1236))

        dictComptes.Add("Crediteurs", cptCrediteurs)
        dictComptes.Add("Debiteurs", cptDebiteurs)

        'Afficher les comptes créditeurs à partir du dict

        If dictComptes.ContainsKey("Crediteurs") Then
            For Each compteB In dictComptes.Item("Crediteurs")
                Console.WriteLine(compteB)
            Next
        End If



#End Region

#Region "Tri de collections"

        Dim comptes As New List(Of CompteBancaire)
        comptes.Add(New CompteBancaire("der148", 4000))
        comptes.Add(New CompteBancaire("mpl859", 1200))
        comptes.Add(New CompteBancaire("qsd145", 3100))

        comptes.Sort() 'la classe COmpteBancaire doit implémenter l'interface IComprarable (comparateur par defaut)

        For Each cpte In comptes
            Console.WriteLine(cpte)
        Next

        Console.WriteLine("Tri par solde décroissant:")
        comptes.Sort(New SoldeDecroissant())
        For Each cpte In comptes
            Console.WriteLine(cpte)
        Next

        Console.WriteLine("Tri par numéro croissant:")
        comptes.Sort(New NumeroCroissant())

        For Each cpte In comptes
            Console.WriteLine(cpte)
        Next

        Console.WriteLine("Tri par numéro décroissant:")
        comptes.Sort(New NumeroDecroissant())

        For Each cpte In comptes
            Console.WriteLine(cpte)
        Next


#End Region

#Region "Fichiers"

        Console.WriteLine("***************Fichiers*******************")
        '.net fournit un certain nombre de classes qui permettent de manipuler les fichiers et les dossiers
        'Directory: pour les répertoires
        'File et FileInfos: 2 classes qui proposent les mm méthodes, elles sont d'instances pour FileInfos et
        'shared pour File
        'Pour les lectures/écritures: StreamReader - StreamWriter

        'Directory:
        Directory.CreateDirectory("rep") ' chemin relatif
        Directory.CreateDirectory("c:\tmp") ' chemin absolut

        'Lister le contenu d'un rép:
        Dim myFiles() As String = Directory.GetFiles("c:\myRep\", "*.txt", SearchOption.AllDirectories)

        For Each fl In myFiles
            Console.WriteLine(fl)
        Next

        'File:
        File.Copy("c:\myRep\fichier.txt", "c:\myRep\copy.txt", True)

        'FileInfo:
        Dim infos As New FileInfo("c:\myRep\fichier.txt")
        Console.WriteLine("Date de création: " & infos.CreationTime)
        Console.WriteLine("Date du dernier accès: " & infos.LastAccessTime)
        Console.WriteLine("Date de la derniere modif: " & infos.LastWriteTime)
        Console.WriteLine("Extension du fichier: " & infos.Extension)
        Console.WriteLine("Taille du fichier en octets: " & infos.Length)

        'Ecriture dans un fichier:
        'Charger le fichier dans un flux
        'Exécuter les opérations (lecture/écriture)
        'Fermer le flux

        Dim sw As New StreamWriter("c:\myRep\file.txt", append:=True)
        sw.Write("contenu du fichier")
        sw.Close()

        'Lecture d'un fichier:
        Dim sr As New StreamReader("c:\myRep\file.txt")
        Dim contenu = sr.ReadToEnd()
        sr.Close()

        Console.WriteLine(contenu)

        Tools.EcritureFichier("c:\myRep\demo.txt", "contenu du fichier....")
        Console.WriteLine(Tools.LectureFichier("c:\myRep\demo.txt"))


#End Region

#Region "Sérialisation"

        Console.WriteLine("************Sérialisation*************")
        'Sérialisation: mécanisme qui permet de sauvegarder l'état d'un objet dans un support de persistence: fichier, BD....
        '3 types de sérialisations:
        'Binaire: BinaryFormatter
        'Xml: XmlSerializer
        'Json: DataContractJsonSerializer


        Dim lc As New List(Of CompteBancaire)
        lc.Add(New CompteBancaire("der148", 4000))
        lc.Add(New CompteBancaire("mpl859", 1200))
        lc.Add(New CompteBancaire("qsd145", 3100))

        Console.WriteLine("*********Sérialisation binaire:")
        Tools.ExportBIN("c:\myRep\comptes.bin", lc)

        For Each cp In Tools.ImportBIN("c:\myRep\comptes.bin")
            Console.WriteLine(cp)
        Next

        Console.WriteLine("*********Sérialisation xml:")
        Tools.ExportXML("c:\myRep\comptes.xml", lc)
        For Each cpt In Tools.ImportXML("c:\myRep\comptes.xml")
            Console.WriteLine(cpt)
        Next


        Console.WriteLine("*********Sérialisation json:")
        Tools.ExportJSON("c:\myRep\comptes.json", lc)
        For Each cpt In Tools.ImportJSON("c:\myRep\comptes.json")
            Console.WriteLine(cpt)
        Next

        Console.WriteLine("*********Sérialisation csv:")
        Tools.ExportCSV("c:\myRep\comptes.csv", lc, ";")
        For Each cpt In Tools.ImportCSV("c:\myRep\comptes.csv", ";")
            Console.WriteLine(cpt)
        Next

#End Region

#Region "Généricité"
        Console.WriteLine("****************Généricité*****************")
        'Le concept de généricité permet de d'exprimer des classes et des méthodes qui sont identiques sur le plan algorithmique
        'mais qui diffèrent sur la base des types

        Dim myGen As New GenericClass(Of String)
        myGen.a = "a"
        myGen.b = "b"
        myGen.Swap()
        Console.WriteLine($"{myGen.a} - {myGen.b}")

        Dim myGen2 As New GenericClass(Of Integer)
        myGen2.a = 10
        myGen2.b = 10
        myGen2.Swap()
        Console.WriteLine($"{myGen2.a} - {myGen2.b}")

#End Region

#Region "Reflection - Introspection"

        Console.WriteLine("*****************Reflection***************")

        'Concept qui permet de découvrir les types (classes) et de pouvoir invoquer leur membres dynamiquement
        Dim empType As Type = GetType(Employes)

        Console.WriteLine(">>> Propriétés de Employes:")
        Dim props() As PropertyInfo = empType.GetProperties()

        For Each prop In props
            Console.WriteLine(prop.Name)
        Next

        Console.WriteLine(">>> Méthodes de Employes:")

        Dim methods() As MethodInfo = empType.GetMethods()
        For Each methode In methods
            Console.WriteLine(methode.Name)
        Next

        'Appel de la méthode Afficher dynamiquement (méthode d'instance)

        Dim methodAfficher As MethodInfo = empType.GetMethod("Afficher")

        'Instancier la classe Employes
        Activator.CreateInstance(empType) 'Appel du conctrcuteur sans params
        Dim emp As Employes = CType(Activator.CreateInstance(empType, "DUPONT", "Jean"), Employes) 'Appel du constrcuteur sans params

        If methodAfficher.IsPublic Then
            If Not methodAfficher.IsStatic Then
                methodAfficher.Invoke(emp, Nothing)
            End If

        End If

        ToolsGeneric.ExportCSV("c:\myRep\compteGen.csv", lc, ";")
        For Each cpte In ToolsGeneric.ImportCSV(Of CompteBancaire)("c:\myRep\compteGen.csv", ";")
            Console.WriteLine(cpte)
        Next

#End Region

#Region "Approche evenementielle"

        'Utilise 2 types d'objets:
        'Publisher (sujet - objet observé): définit un Event et le déclenche
        'Subscriber (abonné - observer): possède un attribut
        'WithEvent + une méthode public sub qui prend les mm params que le subscriber

        Console.WriteLine("***********Event - WhithEven - RaiseEvent*********")

        Dim compteB2 As New CompteBancaire("dsdq15", 1000)
        Dim abonne As New Abonne(compteB2)

        compteB2.Retrait(5000)

#End Region

#Region "Bases de données"

        ' Une application .net utilise le driver (connecter) ADO.NET pour interagir avec une BD.
        ' Pour une BD SqlServer, le driver est fournit System.Data.
        ' Pour un autre type de BD, on doit télécharger le connecter via Nuget

        ' Mise en place de la couche d'accès aux données (Repository - DAO):
        ' 1- Créer la BD si elle n'existe pas
        ' 2- Télécharger le driver (connecter ADO.NET) - SqlServer driver fournit (System.Data)
        ' 3- Pour chaque classe objet, créer une table
        ' 4- Créer une classe qui va gérer la connexion à la BD 
        ' 5- Pour chaque classe objet, créer une classe Repository contenant les méthodes de persistence classiques
        '    CRUD (Create - Read - Update - Delete)

#End Region




        'Maintenir la console active
        Console.ReadLine()

    End Sub

    Private Function Surface(hauteur As Integer, largeur As Integer) As Double
        Return hauteur * largeur
    End Function

    'Polymorphisme par sous typage
    Private Sub Son(a As Animal)
        a.EmettreSon()
    End Sub

    'Polymorphisme Ad_Hoc: déconseillé en pratique
    Private Sub Son2(o As Object)
        If TypeOf o Is Animal Then
            Dim a As Animal = CType(o, Animal)
            a.EmettreSon()
        End If
    End Sub

    'Polymorphisme par type générique
    Private Sub Son3(Of T As Animal)(o As T)
        o.EmettreSon()
    End Sub

    Private Sub mA()

    End Sub
    Private Sub mB()

    End Sub
    Private Sub mC()

    End Sub

    Private Sub myMethode(m As MyClasse)

    End Sub

    ''' <summary>
    ''' Méthode qui génère une exception si x = 0
    ''' </summary>
    ''' <param name="x"></param>
    ''' <exception cref="Exception"></exception>
    Public Sub Division(x As Integer)
        'Option1: gérer l'exception dans la méthode
        'Try
        '    Console.WriteLine(10 \ x)
        'Catch ex As Exception
        '    Console.WriteLine("exception gérée par la méthode......")
        'End Try

        'Option2: faire une remontée d'exception - les appelants doivent gérer l'exception
        If x <> 0 Then
            Console.WriteLine(10 \ x)
        Else
            'Soulever une exception - déclencher une exception
            Throw New Exception("Division par zéro................")
        End If

    End Sub
End Module
