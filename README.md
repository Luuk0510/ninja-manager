# Ninja Manager 
Dit project is gemaakt met een mede student.
Het project omvat de creatie van een administratieve applicatie voor het beheer van ninja's en hun uitrusting via een virtuele winkel

## Projectomschrijving
In opdracht van een gamestudio ontwikkelen studenten een webapplicatie waarmee gebruikers uitrustingen voor ninja's kunnen beheren en aankopen binnen een gegeven budget.
De applicatie biedt gedetailleerde weergave van statistieken gebaseerd op de aangeschafte uitrustingen, en ondersteunt gebruikers in hun aankoopbeslissingen.

## Functionele Eisen
### Ninja
- Beheer: Mogelijkheid om ninja's toe te voegen, te wijzigen, en te verwijderen (CRUD).
- Inventory Reset: Mogelijkheid om de inventory van een ninja te resetten en de ninja 'naakt' te starten met teruggave van goud.
- Statistieken: Weergave van totale kracht, intelligentie, behendigheid, en de waarde in goud van de uitrusting.

### Equipment
- Beheer: Mogelijkheid om nieuwe uitrustingen toe te voegen, te wijzigen en te verwijderen (CRUD).
- Categorieën: Minstens drie verschillende uitrustingen per categorie, waaronder Hoofd, Borst, Hand, Voeten, Ring, en Ketting.

### Shop
- Aankopen: Mogelijkheid om uitrustingen per categorie te bekijken en aan te kopen als de ninja genoeg goud heeft.
- Verkoop: Mogelijkheid om een uitrusting te verkopen en het geld terug te krijgen.

### Technische Eisen
- Framework: ASP.NET MVC.
- Database: Dataopslag met MSSQL en Entity Framework, met voorkeur voor model-first benadering.
- Relatie: Veel-op-veel relatie tussen Ninja en Gear.
- Architectuur: Gebruik van het MVC patroon en scheiding van presentatielogica en businesslogica via Class Libraries.
