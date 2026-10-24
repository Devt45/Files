# Files — édition Everything (fork perso)

Fork de [files-community/Files](https://github.com/files-community/Files) dont la barre de recherche
utilise [Everything](https://www.voidtools.com/) (voidtools) au lieu de la recherche Windows.

Intégration Everything reprise de [DDwsgood/Files-Everything](https://github.com/DDwsgood/Files-Everything)
(3 commits), rebasée sur la dernière version de Files, avec en plus :

- **Choix de la portée** : *Paramètres → Fichiers et dossiers → Rechercher sur tout le PC avec Everything*.
  - Désactivé (défaut) : recherche dans le dossier actuel et ses sous-dossiers.
  - Activé : recherche sur tous les disques indexés par Everything (limitée à 5000 résultats).
  - Aussi disponible comme action **« Rechercher sur tout le PC »** (assignable à un raccourci clavier
    ou ajoutable à la barre d'outils).
- Recherche « contient » (comme la recherche native) au lieu de « commence par ».

Repli automatique sur la recherche Windows si Everything n'est pas lancé, pour les lecteurs réseau,
USB, WSL et les tags. DLL du SDK Everything identiques à celles du SDK officiel (SHA-256 vérifiés).

Le paquet s'installe sous le nom **Files - Dev** et cohabite avec la version du Store.
