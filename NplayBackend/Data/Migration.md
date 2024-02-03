https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/

#### Lag ny migration


Add-Migration -name {name} -verbos

#### Rull tilbake til spesifikk migration

Update-Database InitialEmpty

#### Slett siste migration

Remove-Migration


#### Rull ut siste migration

Update-Database
