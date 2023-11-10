<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - Mon application ASP.NET</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")
</head>
<body>
    <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-dark">
        <div class="container">
            @Html.ActionLink("Nom d'application", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" title="Activer/désactiver la navigation" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse d-sm-inline-flex justify-content-between">
                <ul class="navbar-nav flex-grow-1">
                    <li>@Html.ActionLink("Accueil", "Index", "Home", New With {.area = ""}, New With {.class = "nav-link"})</li>
                    <li>@Html.ActionLink("À propos de", "About", "Home", New With {.area = ""}, New With {.class = "nav-link"})</li>
                    <li>@Html.ActionLink("Gestion des produits", "Index", "Produit", New With {.area = ""}, New With {.class = "nav-link"})</li>
                </ul>
                @If Session("email") IsNot Nothing Then
                    @<ul Class="nav navbar-nav navabr-right">
                        <li>Bienvenue: @Session("email")</li>
                        <li>@Html.ActionLink("Déconnexion", "logout", "Account")</li>
                    </ul>
                Else
                    @<ul Class="nav navbar-nav navabr-right">
                        <li>@Html.ActionLink("Connexion", "login", "Account")</li>
                    </ul>
                End If
            </div>
        </div>
    </nav>
    <div Class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - Mon application ASP.NET</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
