-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : ven. 10 déc. 2021 à 09:12
-- Version du serveur :  5.7.31
-- Version de PHP : 7.4.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `bddpraticien`
--

-- --------------------------------------------------------

--
-- Structure de la table `activite_compl`
--

DROP TABLE IF EXISTS `activite_compl`;
CREATE TABLE IF NOT EXISTS `activite_compl` (
  `AC_NUM` int(11) NOT NULL AUTO_INCREMENT,
  `AC_DATE` datetime NOT NULL,
  `AC_LIEU` varchar(25) COLLATE utf8_bin NOT NULL,
  `AC_THEME` varchar(30) COLLATE utf8_bin NOT NULL,
  `AC_MOTIF` varchar(400) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`AC_NUM`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `activite_compl`
--

INSERT INTO `activite_compl` (`AC_NUM`, `AC_DATE`, `AC_LIEU`, `AC_THEME`, `AC_MOTIF`) VALUES
(1, '2021-12-16 17:07:00', 'Montreuil', 'conférence sida', 'tous concernés'),
(2, '2021-12-09 16:00:18', 'Montreuil', 'conférence dentaire', 'lavez-vous les dents'),
(3, '2022-01-01 00:00:00', 'Drancy', 'Ouverture laboratoire', 'Ouverture du laboratoire de Drancy'),
(4, '2021-12-28 18:04:08', 'Boulogne-Billancourt', 'Conférence sur la vue', 'Soignez votre vue avec ce top 10 des meilleures astuces'),
(7, '2022-04-13 13:39:26', 'Nanterre', 'salon pharmacosmetech', 'Venez découvrir les nouvelles tech et process dans le domaine pharmacetique'),
(8, '2022-02-11 10:39:26', 'Congrès de Paris', 'Journées de l\'Innovation', 'Nouveau nom, nouveau format… les JIB - anciennement Journées Internationales de Biologie deviennent les Journées de l\'Innovation en Biologie.'),
(9, '2022-04-01 10:44:43', 'Lille', ' NaturaBio', 'Pour sa 19ème édition, le salon NATURABIO rassemblera 210 EXPOSANTS dans le Hall Bruxelles de Lille Grand Palais.'),
(10, '2022-05-21 10:44:43', 'Paris', 'Congrès annuel ADF', 'Une nouvelle édition sous le signe du rassemblement ! Changement des modalités d’exercice, nouvelles technologies, mobilisation des praticiens…'),
(11, '2022-08-09 09:03:46', 'Paris', 'Les Thermalies', 'Les dernières tendances en matière de santé et bien-être sont au salon Thermalies Paris du 23 au 26 janvier 2020 au Carrousel du Louvre : les acteurs principaux de la Thalassothérapie, du Thermalisme, de la Balnéothérapie et du Spa, vous recevront au sein des 6 pavillons thématiques pour vous faire découvrir les bienfaits de l’eau de mer et de source sur le corps.');

-- --------------------------------------------------------

--
-- Structure de la table `inviter`
--

DROP TABLE IF EXISTS `inviter`;
CREATE TABLE IF NOT EXISTS `inviter` (
  `AC_NUM` int(11) NOT NULL,
  `PRA_NUM` smallint(6) NOT NULL,
  `SPECIALISTEON` tinyint(1) NOT NULL,
  PRIMARY KEY (`AC_NUM`,`PRA_NUM`),
  KEY `PRA_NUM` (`PRA_NUM`),
  KEY `AC_NUM` (`AC_NUM`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `inviter`
--

INSERT INTO `inviter` (`AC_NUM`, `PRA_NUM`, `SPECIALISTEON`) VALUES
(1, 2, 0),
(2, 2, 0),
(4, 1, 0),
(4, 19, 0),
(7, 8, 1),
(8, 1, 0),
(9, 14, 1),
(11, 15, 1);

-- --------------------------------------------------------

--
-- Structure de la table `posseder`
--

DROP TABLE IF EXISTS `posseder`;
CREATE TABLE IF NOT EXISTS `posseder` (
  `PRA_NUM` smallint(6) NOT NULL,
  `SPE_CODE` int(11) NOT NULL,
  `POS_DIPLOME` tinyint(1) NOT NULL,
  `POS_COEFPRESCRIPTION` double NOT NULL,
  PRIMARY KEY (`PRA_NUM`,`SPE_CODE`),
  KEY `SPE_CODE` (`SPE_CODE`),
  KEY `PRA_NUM` (`PRA_NUM`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `posseder`
--

INSERT INTO `posseder` (`PRA_NUM`, `SPE_CODE`, `POS_DIPLOME`, `POS_COEFPRESCRIPTION`) VALUES
(1, 3, 1, 3),
(11, 4, 1, 10),
(11, 13, 1, 8),
(11, 15, 1, 10),
(14, 4, 1, 5),
(14, 13, 1, 7),
(14, 15, 1, 10),
(17, 20, 1, 10),
(17, 24, 1, 6),
(18, 10, 1, 5),
(18, 20, 1, 10),
(18, 24, 1, 10);

-- --------------------------------------------------------

--
-- Structure de la table `praticien`
--

DROP TABLE IF EXISTS `praticien`;
CREATE TABLE IF NOT EXISTS `praticien` (
  `PRA_NUM` smallint(6) NOT NULL AUTO_INCREMENT,
  `PRA_NOM` varchar(25) COLLATE utf8_bin NOT NULL,
  `PRA_PRENOM` varchar(30) COLLATE utf8_bin NOT NULL,
  `PRA_ADRESSE` varchar(50) COLLATE utf8_bin NOT NULL,
  `PRA_CP` varchar(5) COLLATE utf8_bin NOT NULL,
  `PRA_VILLE` varchar(25) COLLATE utf8_bin NOT NULL,
  `PRA_COEFNOTORIETE` int(11) NOT NULL,
  `TYP_CODE` int(11) NOT NULL,
  PRIMARY KEY (`PRA_NUM`),
  KEY `TYP_CODE` (`TYP_CODE`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `praticien`
--

INSERT INTO `praticien` (`PRA_NUM`, `PRA_NOM`, `PRA_PRENOM`, `PRA_ADRESSE`, `PRA_CP`, `PRA_VILLE`, `PRA_COEFNOTORIETE`, `TYP_CODE`) VALUES
(1, 'Ashanin', 'Sevastian', '7 Rue Francis de Pressensé', '75014', 'Paris', 5, 1),
(2, 'Read', 'Ash', '40 Rue Worth', '92150', 'Suresnes', 3, 10),
(5, 'Gonzales', 'Ash ', '35 Rte de Chartres', '91940', 'Gometz-le-Châtel', 7, 4),
(8, 'Mccarthy', 'Aaren ', '1 Rue Velpeau', '92160', 'Antony', 3, 4),
(9, 'Rogers', 'Ryan ', '5 Rue Velpeau', '92160', 'Antony', 6, 4),
(10, 'Bailey', 'Kiran ', '4 Rue du Tour de l\'Étang', '92350', 'Le Plessis-Robinson', 3, 10),
(11, 'Houghton', 'Kit ', '1 Av. de la Paix', '92140', 'Clamart', 10, 11),
(12, 'Tyler', 'Gale ', '3 Rue Arthur Groussier', '93140', 'Bondy', 6, 7),
(13, 'Padilla', 'Leigh ', '9 Rue Roger Salomon', '93700', 'Drancy', 2, 8),
(14, 'Casey', 'Brice ', '43 All. du Plateau', '93250', 'Villemomble', 8, 11),
(15, 'O\'connor', 'Riley ', '46 Rue de Villeparisis', '77290', 'Mitry-Mory', 8, 11),
(16, 'Mitchell', 'Jackie ', '4 Rem du Cr aux Bêtes', '77160', 'Provins', 0, 7),
(17, 'Young', 'Val ', '12 Av. de l\'Arbre À la Quenée', '78490', 'Méré', 1, 3),
(18, 'Pearce', 'Nicky ', '7 Rue du Bréau', '77130', 'Varennes-sur-Seine', 10, 3),
(19, 'Davidson', 'Brynn ', '48 Av. Etienne Dailly', '77140', 'Nemours', 5, 2);

-- --------------------------------------------------------

--
-- Structure de la table `specialite`
--

DROP TABLE IF EXISTS `specialite`;
CREATE TABLE IF NOT EXISTS `specialite` (
  `SPE_CODE` int(11) NOT NULL AUTO_INCREMENT,
  `SPE_LIBELLE` varchar(150) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`SPE_CODE`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `specialite`
--

INSERT INTO `specialite` (`SPE_CODE`, `SPE_LIBELLE`) VALUES
(3, 'Anatomie et cytologie pathologiques'),
(4, 'Cardiologie et maladies vasculaires'),
(5, 'Dermatologie et vénérologie'),
(6, 'Endocrinologie et métabolismes'),
(7, 'Gastro-entérologie et hépatologie'),
(8, 'Génétique médicale'),
(9, 'Génétique médicale'),
(10, 'Médecine interne'),
(11, 'Médecine nucléaire'),
(12, 'Médecine physique et de réadaptation'),
(13, 'Néphrologie'),
(14, 'Neurologie'),
(15, 'Oncologie'),
(16, 'Pneumologie'),
(17, 'Radiodiagnostic et imagerie médicale'),
(18, 'Rhumatologie'),
(19, 'Médecine générale, durée : trois ans'),
(20, 'Chirurgie générale'),
(21, 'Neurochirurgie'),
(22, 'Ophtalmologie'),
(23, 'Oto-rhino-laryngologie'),
(24, 'Chirurgie infantile');

-- --------------------------------------------------------

--
-- Structure de la table `type_praticien`
--

DROP TABLE IF EXISTS `type_praticien`;
CREATE TABLE IF NOT EXISTS `type_praticien` (
  `TYP_CODE` int(11) NOT NULL AUTO_INCREMENT,
  `TYP_LIBELLE` varchar(25) COLLATE utf8_bin NOT NULL,
  `TYP_LIEU` varchar(35) COLLATE utf8_bin NOT NULL,
  PRIMARY KEY (`TYP_CODE`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Déchargement des données de la table `type_praticien`
--

INSERT INTO `type_praticien` (`TYP_CODE`, `TYP_LIBELLE`, `TYP_LIEU`) VALUES
(1, 'Anesthésiste', 'Hopital'),
(2, 'Pharmacien', 'Pharmacie'),
(3, 'Chirurgien', 'Hopital'),
(4, 'Médecin généraliste', 'Cabinet'),
(7, 'Docteur', 'Hopital'),
(8, 'Neurologue', 'Hopital'),
(9, 'Ophtalmologiste', 'Cabinet'),
(10, 'Psychologue', 'Cabinet'),
(11, 'Cancérologue', 'Hopital');

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `inviter`
--
ALTER TABLE `inviter`
  ADD CONSTRAINT `inviter_ibfk_2` FOREIGN KEY (`AC_NUM`) REFERENCES `activite_compl` (`AC_NUM`),
  ADD CONSTRAINT `inviter_ibfk_3` FOREIGN KEY (`PRA_NUM`) REFERENCES `praticien` (`PRA_NUM`);

--
-- Contraintes pour la table `posseder`
--
ALTER TABLE `posseder`
  ADD CONSTRAINT `posseder_ibfk_1` FOREIGN KEY (`SPE_CODE`) REFERENCES `specialite` (`SPE_CODE`),
  ADD CONSTRAINT `posseder_ibfk_2` FOREIGN KEY (`PRA_NUM`) REFERENCES `praticien` (`PRA_NUM`);

--
-- Contraintes pour la table `praticien`
--
ALTER TABLE `praticien`
  ADD CONSTRAINT `praticien_ibfk_2` FOREIGN KEY (`TYP_CODE`) REFERENCES `type_praticien` (`TYP_CODE`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
