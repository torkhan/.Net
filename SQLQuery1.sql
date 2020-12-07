--Q1 Obtenir la liste des 10 villes les plus peuplées en 2012
SELECT TOP 10 ville_population_2012 FROM villes_france_free ORDER BY ville_population_2012 DESC;
--Q2 Obtenir la liste des 50 villes ayant la plus faible superficie
SELECT TOP 50 * FROM villes_france_free ORDER BY ville_surface ASC;
--Q3 Obtenir la liste des départements d’outres-mer, c’est-à-dire ceux dont le numéro de département commencent par “97”
SELECT * FROM departement where departement_code like '97%';
--Q4 Obtenir le nom des 10 villes les plus peuplées en 2012, ainsi que le nom du département associé
SELECT TOP 10 v.ville_nom, d.departement_nom FROM villes_france_free as v
LEFT JOIN departement as d on d.departement_code = v.ville_departement  ORDER BY ville_population_2012 DESC;
--Q5 Obtenir la liste du nom de chaque département, associé à son code et du nombre de commune au sein de ces département, en triant afin d’obtenir en priorité les départements qui possèdent le plus de communes
--SELECT d.departement_nom, d.departement_code from departement as d LEFT JOIN COUNT(villes_france_free) as nbre_communes ORDER BY 
--Q6 Obtenir la liste des 10 plus grands départements, en terme de superficie
SELECT TOP 10 departement_nom , SUM(ville_surface) as dep_surface FROM villes_france_free INNER JOIN departement on departement_code= ville_departement
GROUP BY departement_nom;

--Q7 Compter le nombre de villes dont le nom commence par “Saint”
SELECT COUNT(*) as nbre_ville FROM villes_france_free where ville_nom like 'Saint%';
--Q8 Obtenir la liste des villes qui ont un nom existants plusieurs fois, 
--et trier afin d’obtenir en premier celles dont le nom est le plus souvent utilisé par plusieurs communes
Select ville_nom , COUNT(*) as nbre_villes FROM villes_france_free GROUP BY ville_nom ORDER BY nbre_villes DESC;

--Q9 Obtenir en une seule requête SQL la liste des villes dont la superficie est supérieur à la superficie moyenne
SELECT * FROM villes_france_free where ville_surface > (SELECT AVG(ville_surface) FROM villes_france_free);

--Q10 Obtenir la liste des départements qui possèdent plus de 2 millions d’habitants
Select ville_departement, SUM(ville_population_2012) as pop FROM villes_france_free GROUP BY ville_departement HAVING SUM (ville_population_2012)>2000000;

--Q11 Remplacez les tirets par un espace vide, pour toutes les villes commençant par “SAINT-”(dans la colonne qui contient les noms en majuscule)
UPDATE villes_france_free SET ville_nom = REPLACE(ville_nom, '-',' ') WHERE ville_nom like 'SAINT-%';
