--
-- PostgreSQL database dump
--

-- Dumped from database version 14.4 (Ubuntu 14.4-1.pgdg22.04+1)
-- Dumped by pg_dump version 14.4 (Ubuntu 14.4-1.pgdg22.04+1)

-- Started on 2022-07-14 10:27:39 EEST

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 3444 (class 0 OID 25968)
-- Dependencies: 211
-- Data for Name: Addresses; Type: TABLE DATA; Schema: public; Owner: flexbook
--

INSERT INTO public."Addresses" ("Id", "Street", "Number", "City", "PostCode") VALUES (1, 'Ocean Park Ave', 210, 'New Jersey', '07720');
INSERT INTO public."Addresses" ("Id", "Street", "Number", "City", "PostCode") VALUES (2, 'Agias Barbaras', 231, 'Paleo Faliro', '17563');
INSERT INTO public."Addresses" ("Id", "Street", "Number", "City", "PostCode") VALUES (3, 'Agoniston', 12, 'Paleo Faliro', '17563');
INSERT INTO public."Addresses" ("Id", "Street", "Number", "City", "PostCode") VALUES (4, 'Likourgou', 24, 'Alimos', '19363');
INSERT INTO public."Addresses" ("Id", "Street", "Number", "City", "PostCode") VALUES (5, 'Likourgou', 27, 'Alimos', '19363');
INSERT INTO public."Addresses" ("Id", "Street", "Number", "City", "PostCode") VALUES (6, 'Evergeton', 13, 'Paleon Faliron', '12343');
INSERT INTO public."Addresses" ("Id", "Street", "Number", "City", "PostCode") VALUES (9, 'asd', 1234, 'asdsf', '12334');
INSERT INTO public."Addresses" ("Id", "Street", "Number", "City", "PostCode") VALUES (10, 'Messinias', 11, 'Paleo Faliro', '17563');
INSERT INTO public."Addresses" ("Id", "Street", "Number", "City", "PostCode") VALUES (11, 'sadsaf', 123, 'dsafwef', '23423');
INSERT INTO public."Addresses" ("Id", "Street", "Number", "City", "PostCode") VALUES (12, 'Messinias', 12, 'Paleo Faliro', '12345');
INSERT INTO public."Addresses" ("Id", "Street", "Number", "City", "PostCode") VALUES (14, 'asd', 123, 'asd', '12345');
INSERT INTO public."Addresses" ("Id", "Street", "Number", "City", "PostCode") VALUES (15, 'asdf', 123, 'Paleo Falir', '12345');
INSERT INTO public."Addresses" ("Id", "Street", "Number", "City", "PostCode") VALUES (16, 'CocoStreet', 12, 'Cocoland', '66699');


--
-- TOC entry 3446 (class 0 OID 25976)
-- Dependencies: 213
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: flexbook
--

INSERT INTO public."Users" ("Id", "Username", "Password", "Fullname", "Email", "AddressId", "BirthDate", "PhoneNumber", "Image", "Role") VALUES (1, 'andre_aciman', 'supersecureauthor', 'André Aciman', 'andre_aciman@gmail.com', 1, '1951-01-02 02:00:00.828+02', '7349019838', 'andre_aciman.jpg', 'Author');
INSERT INTO public."Users" ("Id", "Username", "Password", "Fullname", "Email", "AddressId", "BirthDate", "PhoneNumber", "Image", "Role") VALUES (2, 'fotis_papanastasiou', 'supersecureauthor', 'Fotis Papanastasiou', 'fotis_papanastasiou@hotmail.com', 2, '1981-02-06 02:00:00.828+02', '6945873422', 'fotis_papanastasiou.jpg', 'Author');
INSERT INTO public."Users" ("Id", "Username", "Password", "Fullname", "Email", "AddressId", "BirthDate", "PhoneNumber", "Image", "Role") VALUES (3, 'evgenios_trivizas', 'supersecureauthor', 'Evgenios Trivizas', 'evgenios_trivizas@gmail.com', 3, '1946-10-08 02:00:00.828+02', '6965262213', 'evgenios_trivizas.jpg', 'Author');
INSERT INTO public."Users" ("Id", "Username", "Password", "Fullname", "Email", "AddressId", "BirthDate", "PhoneNumber", "Image", "Role") VALUES (4, 'sarantos_kargakos', 'supersecureauthor', 'Sarantos Kargakos', 'sarantos_kargakos@hotmail.com', 4, '1937-07-16 02:00:00.828+02', '6933465346', 'sarantos_kargakos.jpg', 'Author');
INSERT INTO public."Users" ("Id", "Username", "Password", "Fullname", "Email", "AddressId", "BirthDate", "PhoneNumber", "Image", "Role") VALUES (5, 'giannis_garoutsos', 'supersecureauthor', 'Giannis Garoutsos', 'giannis_garoutsos@gamil.com', 5, '1963-03-12 02:00:00.828+02', '6936473386', 'giannis_garoutsos.jpg', 'Author');
INSERT INTO public."Users" ("Id", "Username", "Password", "Fullname", "Email", "AddressId", "BirthDate", "PhoneNumber", "Image", "Role") VALUES (8, 'kostakis', 'supersecurecustomer', 'Kostakis Kalogero', 'kostakis_kalokero@gmail.com', 10, '2001-04-01 03:00:00.828+03', '6944675834', 'customer_kostas.png', 'Customer');
INSERT INTO public."Users" ("Id", "Username", "Password", "Fullname", "Email", "AddressId", "BirthDate", "PhoneNumber", "Image", "Role") VALUES (13, 'asd', 'asdf', 'asdfs asdf', 'sadas@dsa.csa', 15, '2022-07-06 03:00:00.828+03', '2103212432', 'default_customer.jpg', 'Customer');
INSERT INTO public."Users" ("Id", "Username", "Password", "Fullname", "Email", "AddressId", "BirthDate", "PhoneNumber", "Image", "Role") VALUES (14, 'book_lover', 'supersecurecustomer', 'Book Lovarrr', 'book_lover@bookland.coco', 16, '2001-07-18 03:00:00.828+03', '6934455667', 'book_lover.jpg', 'Customer');


--
-- TOC entry 3455 (class 0 OID 26090)
-- Dependencies: 222
-- Data for Name: Authors; Type: TABLE DATA; Schema: public; Owner: flexbook
--

INSERT INTO public."Authors" ("Id", "Description") VALUES (1, 'An Italian-American writer. Born and raised in Alexandria, Egypt, he is currently a distinguished professor at the Graduate Center of City University of New York');
INSERT INTO public."Authors" ("Id", "Description") VALUES (2, 'Ο Φώτης Παπαναστασίου είναι Ειδικός Παιδαγωγός, αριστούχος απόφοιτος του Πανεπιστημίου Θεσσαλίας, με μεταπτυχιακό στη Σχολική Ψυχολογία.');
INSERT INTO public."Authors" ("Id", "Description") VALUES (3, 'Ο Ευγένιος Τριβιζάς είναι δικηγόρος, πτυχιούχος της Νομικής και των Πολιτικών και Οικονομικών Επιστημών του Πανεπιστημίου Αθηνών, κάτοχος πτυχίου Master of Laws (University College London) και διδάκτωρ Νομικής του Πανεπιστημίου του Λονδίνου (London School of Economics and Political Science). Επίσης Senior Research Fellow του Πανεπιστημίου Λονδίνου.');
INSERT INTO public."Authors" ("Id", "Description") VALUES (4, 'Ο Σαράντος Καργάκος γεννήθηκε στο Γύθειο Λακωνίας, σπούδασε φιλολογία στο Πανεπιστήμιο Αθηνών και υπήρξε συνεργάτης πολλών μεγάλων φροντιστηρίων στην Αθήνα.');
INSERT INTO public."Authors" ("Id", "Description") VALUES (5, 'Από μικρό παιδί ήταν φαινόμενο, σε ηλικία πέντε ετών γνώριζε όλη την προπαίδεια, ως μαθητής του Δημοτικού σχολείου μελετούσε από μόνος του βιβλία κβαντικής φυσικής όταν έβοσκε τα πρόβατα στα βουνά της Οκτωνιάς.');


--
-- TOC entry 3452 (class 0 OID 26011)
-- Dependencies: 219
-- Data for Name: Products; Type: TABLE DATA; Schema: public; Owner: flexbook
--

INSERT INTO public."Products" ("Id", "CreatedOn", "UpdatedOn", "Title", "Description", "Image", "StartingPrice", "FinalPrice") VALUES (3, '2022-07-09 00:13:14.546614+03', '2022-07-09 00:13:14.546614+03', 'Call Me By Your Name', 'Andre Aciman''s Call Me by Your Name is the story of a sudden and powerful romance that blossoms between an adolescent boy and a summer guest at his parents'' cliffside mansion on the Italian Riviera.', 'call_me_by_your_name.jpeg', 9.77, -1);
INSERT INTO public."Products" ("Id", "CreatedOn", "UpdatedOn", "Title", "Description", "Image", "StartingPrice", "FinalPrice") VALUES (4, '2022-07-09 00:22:06.82587+03', '2022-07-09 00:22:06.82587+03', 'Find Me', 'Elio believes he has left behind his first love - but as an affair with an older man intensifies, his thoughts turn to the past and to Oliver.', 'find_me.jpeg', 11.15, -1);
INSERT INTO public."Products" ("Id", "CreatedOn", "UpdatedOn", "Title", "Description", "Image", "StartingPrice", "FinalPrice") VALUES (5, '2022-07-09 11:34:29.461506+03', '2022-07-09 11:34:29.461506+03', 'ΔΕΠΥράζει, Πρακτικός οδηγός για γονείς και εκπαιδευτικούς', 'Η Διαταραχή Ελλειμματικής Προσοχής ή/και Υπερκινητικότητας (ΔΕΠΥ) είναι μία από τις πιο συχνά εμφανιζόμενες διαταραχές συμπεριφοράς, που παρεμποδίζει την ψυχοκοινωνική και ακαδημαϊκή ανάπτυξη του παιδιού, δημιουργεί σοβαρά προβλήματα στους γονείς και στην οικογένειά του, και δυσκολεύει σημαντικά το έργο των εκπαιδευτικών στο σχολείο.', 'depyrazei_praktikos_odigos_gia_goneis_kai_ekpaideftikous.jpeg', 20.33, -1);
INSERT INTO public."Products" ("Id", "CreatedOn", "UpdatedOn", "Title", "Description", "Image", "StartingPrice", "FinalPrice") VALUES (6, '2022-07-09 11:36:15.582579+03', '2022-07-09 11:36:15.582579+03', 'Γίνε Θετικός Άνθρωπος σε 365 Ημέρες', 'Το βιβλίο που κρατάς στα χέρια σου δεν είναι ένα κλασικό βιβλίο µε εύκολες λύσεις και κοινότοπες νουθεσίες που επιδιώκει να σου πει τι πρέπει να κάνεις ως γονέας και τι όχι.', 'gine_thetikos_anthropos_se_365_meres.jpeg', 15.21, -1);
INSERT INTO public."Products" ("Id", "CreatedOn", "UpdatedOn", "Title", "Description", "Image", "StartingPrice", "FinalPrice") VALUES (7, '2022-07-09 11:36:35.767543+03', '2022-07-09 11:36:35.767543+03', 'Τα Τρία Μικρά Λυκάκια', 'Ήταν μια φορά τρία μικρά λυκάκια που ήθελαν να χτίσουν ένα δικό τους σπίτι.', 'ta_tria_mikra_likakia.jpeg', 9.38, -1);
INSERT INTO public."Products" ("Id", "CreatedOn", "UpdatedOn", "Title", "Description", "Image", "StartingPrice", "FinalPrice") VALUES (8, '2022-07-09 11:36:44.725569+03', '2022-07-09 11:36:44.725569+03', 'Φρικαντέλα: Η μάγισσα που μισούσε τα κάλαντα', 'Ήτανε κάποτε μια μάγισσα που τη λέγανε Φρικαντέλα Ζαρζουέλα Σαλμονέλα Στρυφνίνη.', 'frikantela_i_magissa_pou_misouse_ta_kalanta.jpeg', 11.94, -1);
INSERT INTO public."Products" ("Id", "CreatedOn", "UpdatedOn", "Title", "Description", "Image", "StartingPrice", "FinalPrice") VALUES (9, '2022-07-09 11:37:27.15896+03', '2022-07-09 11:37:27.15896+03', 'Μέγας Αλέξανδρος', 'Αφότου σχηματίσθηκε το νεώτερο ελληνικό κράτος, ήσαν πολλοί αυτοί που ασχολήθηκαν με τη ζωή και τη δράση του νεαρού στρατηλάτη, είτε αυτοί ήσαν επίσημοι είτε ερασιτέχνες ιστορικοί. Δυστυχώς, η βιβλιογραφία αυτή αγνοείται στο εξωτερικό.', 'megas_alexandros.jpeg', 18.5, -1);
INSERT INTO public."Products" ("Id", "CreatedOn", "UpdatedOn", "Title", "Description", "Image", "StartingPrice", "FinalPrice") VALUES (10, '2022-07-09 11:37:42.966864+03', '2022-07-09 11:37:42.966864+03', 'Η Ελληνική Επανάσταση του 1821, Τόμος Α''', 'Περιγραφή της μεγάλης ελληνικής επανάστασης', 'i_elliniki_epanastasi_tou_1821_tomos_a.jpeg', 29.68, -1);
INSERT INTO public."Products" ("Id", "CreatedOn", "UpdatedOn", "Title", "Description", "Image", "StartingPrice", "FinalPrice") VALUES (11, '2022-07-09 11:39:19.670555+03', '2022-07-09 11:39:19.670555+03', 'Εισαγωγή στη Μηχανική των Ρευστών', 'Μηχανική Ρευστών', 'eisagogi_sti_michaniki_ton_reyston.jpeg', 19.08, -1);
INSERT INTO public."Products" ("Id", "CreatedOn", "UpdatedOn", "Title", "Description", "Image", "StartingPrice", "FinalPrice") VALUES (12, '2022-07-09 19:16:11.747095+03', '2022-07-09 19:16:11.747095+03', 'Ολοκληρώματα', 'Είναι το βιβλίο που κάνει κυριολεκτικά απλές τις πιο δύσκολες έννοιες και διαδικασίες.', 'olokliromata.jpeg', 13.27, -1);


--
-- TOC entry 3457 (class 0 OID 26112)
-- Dependencies: 224
-- Data for Name: Books; Type: TABLE DATA; Schema: public; Owner: flexbook
--

INSERT INTO public."Books" ("Id", "ISBN", "Genre", "Publisher", "PageCount", "Language", "Summary", "AuthorId") VALUES (3, '9781786495259', 'Literature', 'Atlantic Books', 256, 'English', 'Each is unprepared for the consequences of their attraction, when, during the restless summer weeks, unrelenting currents of obsession, fascination, and desire intensify their passion and test the charged ground between them. Recklessly, the two verge toward the one thing both fear they may never truly find again: total intimacy. It is an instant classic and one of the great love stories of our time.', 1);
INSERT INTO public."Books" ("Id", "ISBN", "Genre", "Publisher", "PageCount", "Language", "Summary", "AuthorId") VALUES (4, '9780571356508', 'Literature', 'Faber & Faber', 272, 'English', 'Oliver, a college professor, husband and father, is preparing to leave New York. The imminent trip stirs up longing and regret, awakening an old desire and propelling him towards a decision that could change everything.In Call Me By Your Name, we fell in love with Oliver and Elio. Find Me returns to these unforgettable characters, exploring how love can ripple out from the past and into the future.', 1);
INSERT INTO public."Books" ("Id", "ISBN", "Genre", "Publisher", "PageCount", "Language", "Summary", "AuthorId") VALUES (5, '9789606350344', 'Education', 'Πεδίο', 213, 'Greek', 'Με θεωρητικές γνώσεις, εργαλεία ανίχνευσης της διαταραχής, ασκήσεις και δραστηριότητες, το βιβλίο ''ΔΕΠΥράζει'' επιδιώκει να βοηθήσει τους μαθητές με ΔΕΠΥ να κατακτήσουν δεξιότητες απαραίτητες για την ακαδημαϊκή τους πορεία, την κοινωνική τους ένταξη και τη διαχείριση της συμπεριφοράς τους, αποτελώντας παράλληλα ένα ολοκληρωμένο εργαλείο στα χέρια των εκπαιδευτικών και των γονιών για την ανίχνευση της ΔΕΠΥ και τη δημιουργία ενός προγράμματος παρέμβασης και υποστήριξης.', 2);
INSERT INTO public."Books" ("Id", "ISBN", "Genre", "Publisher", "PageCount", "Language", "Summary", "AuthorId") VALUES (6, '9789606354038', 'Education', 'Πεδίο', 384, 'Greek', 'Βασιζόµενο στη θετική ανατροφή, µια σύγχρονη προσέγγιση που επιτρέπει στους γονείς να χτίσουν και να διατηρήσουν ισχυρούς δεσµούς µε το παιδί σε όλα τα στάδια της αναπτυξιακής του πορείας, το βιβλίο 365 – Γίνε πιο θετικός γονέας σε 365 ηµέρες διαρθρώνεται σε 12 µήνες, καθένας από τους οποίους είναι αφιερωµένος σε έναν τοµέα-στόχο που θα πρέπει να κατακτήσεις. Κάθε τοµέας-στόχος, που παρουσιάζεται µε τρόπο αναλυτικό και εύληπτο, κρίνεται εξίσου σηµαντικός για την ανατροφή του παιδιού.Σκοπός του βιβλίου είναι να παρουσιάσει ορισµένες ιδέες και να σου προσφέρει συµβουλές που θα σε βοηθήσουν στη διαµόρφωση συναισθηµατικά υγιών και υπεύθυνων παιδιών. Απώτατος σκοπός είναι η οικοδόµηση µιας δεµένης και υγιούς οικογένειας, στο πλαίσιο της οποίας τα παιδιά θα νιώθουν αναπόσπαστα και δηµιουργικά µέλη της.Το βιβλίο αυτό θα αποτελέσει ένα πολύτιµο εργαλείο, µια πυξίδα απαραίτητη στο µοναδικό ταξίδι κάθε γονέα για το µεγάλωµα υγιών και ευτυχισµένων παιδιών.', 2);
INSERT INTO public."Books" ("Id", "ISBN", "Genre", "Publisher", "PageCount", "Language", "Summary", "AuthorId") VALUES (7, '9789602402399', 'Children', 'Μίνωας', 71, 'Greek', 'Όμως ο Ρούνι-Ρούνι, το ύπουλο, κακό γουρούνι, είχε άλλα σχέδια στο μυαλό του…', 3);
INSERT INTO public."Books" ("Id", "ISBN", "Genre", "Publisher", "PageCount", "Language", "Summary", "AuthorId") VALUES (8, '9789602191439', 'Children', 'Καλέντης', 64, 'Greek', 'Η Φρικαντέλα ήταν κακιά. Πολύ κακιά. Πάρα πολύ κακιά. Τόσο κακιά ήταν που μισούσε αφάνταστα όλα τα καλά. Αλλά πιο πολύ απ'' όλα η μάγισσα Φρικαντέλα μισούσε τα κάλαντα!', 3);
INSERT INTO public."Books" ("Id", "ISBN", "Genre", "Publisher", "PageCount", "Language", "Summary", "AuthorId") VALUES (9, '9789608411371', 'History', 'ΠεριΤεχνών', 352, 'Greek', 'Τώρα αγνοείται και στο εσωτερικό από τους νεώτερους ιστορικούς και έτσι το ελληνικό αναγνωστικό κοινό εξακολουθεί να τροφοδοτείται με ξένα περί Αλεξάνδρου ''σκευάσματα'', γραμμένα από ιστορικούς που πλέον αδυνατούν να διαβάσουν τις αρχαίες πηγές από το πρωτότυπο, που αγνοούν παντελώς την ελληνική βιβλιογραφία, και μάλιστα κατά τρόπο σκανδαλώδη -που οφείλεται σε ολική ή μερική έλλειψη ελληνομάθειας. Και έτσι πράγματα, που περί Φιλίππου ή Αλεξάνδρου έχουν γραφεί προ εκατό ετών από Έλληνες ιστορικούς, θεωρούνται ''ανακαλύψεις'', όταν γράφονται από ξένους ιστορικούς. ', 4);
INSERT INTO public."Books" ("Id", "ISBN", "Genre", "Publisher", "PageCount", "Language", "Summary", "AuthorId") VALUES (10, '9789600122602', 'History', 'Gutenberg', 768, 'Greek', 'Ιστορικά θέματα ύψιστης σημασίας', 4);
INSERT INTO public."Books" ("Id", "ISBN", "Genre", "Publisher", "PageCount", "Language", "Summary", "AuthorId") VALUES (11, '9789608250888', 'Science', 'SPIN', 368, 'Greek', 'Ένα βιβλίο που αφορά τη μηχανική των πραγματικά ρευστών', 5);
INSERT INTO public."Books" ("Id", "ISBN", "Genre", "Publisher", "PageCount", "Language", "Summary", "AuthorId") VALUES (12, '9789608250116', 'Science', 'SPIN', 252, 'Greek', 'Περιέχει: Επικαμπύλια, Διπλά Τριπλά και Επιφανειακά Ολοκληρώματα.Οι παραπάνω έννοιες παρουσιάζονται με παραδείγματα από τη Φυσική και όχι με πολύπλοκες μαθηματικές εκφράσεις.Συνιστούμε στον αναγνώστη, πριν μελετήσει το βιβλίο αυτό, να επαναλάβει τα αόριστα ολοκληρώματα από το βιβλίο μας: «Μαθηματική Ανάλυση» και τα διανύσματα από το βιβλίο μας:«Μαθήματα Γραμματικής Άλγευρας και Αναλυτικής Γεωμετρίας».', 5);


--
-- TOC entry 3459 (class 0 OID 26231)
-- Dependencies: 226
-- Data for Name: BookReviews; Type: TABLE DATA; Schema: public; Owner: flexbook
--

INSERT INTO public."BookReviews" ("Id", "Rating", "Content", "BookId", "UserId") VALUES (1, 5, 'Best book eveeeer', 3, 8);
INSERT INTO public."BookReviews" ("Id", "Rating", "Content", "BookId", "UserId") VALUES (3, 4, 'With my intellectual background I can iiiiindeed say,<div>that this book satisfies my spiritual needs. I rate it</div><div>with 4 stars because no book is perfect. Not even</div><div>if I was the author!</div>', 3, 14);


--
-- TOC entry 3448 (class 0 OID 25989)
-- Dependencies: 215
-- Data for Name: Comments; Type: TABLE DATA; Schema: public; Owner: flexbook
--

INSERT INTO public."Comments" ("Id", "Content", "CreatedOn", "UpdatedOn", "LikesCount", "UserId", "AuthorHostId") VALUES (1, 'Hey Evgenios, I love your books! Are you single?', '2022-07-13 20:17:48.834323+03', '2022-07-13 20:17:48.834323+03', 0, 13, 3);
INSERT INTO public."Comments" ("Id", "Content", "CreatedOn", "UpdatedOn", "LikesCount", "UserId", "AuthorHostId") VALUES (2, 'I am married and also straight. Sorry my man', '2022-07-13 23:37:36.514296+03', '2022-07-13 23:37:36.514296+03', 0, 3, 3);
INSERT INTO public."Comments" ("Id", "Content", "CreatedOn", "UpdatedOn", "LikesCount", "UserId", "AuthorHostId") VALUES (3, 'Greeting Andre Aciman sir. I may just be your biggest fan. But I have to ask: How does a man of such high intellect like yourself end up in a site like this?', '2022-07-14 00:40:06.958076+03', '2022-07-14 00:40:06.958076+03', 0, 14, 1);
INSERT INTO public."Comments" ("Id", "Content", "CreatedOn", "UpdatedOn", "LikesCount", "UserId", "AuthorHostId") VALUES (4, 'Sorry book_lover, but I am not interested in engaging in a conversation with a rude individual suck as yourself', '2022-07-14 00:45:36.687344+03', '2022-07-14 00:45:36.687344+03', 0, 1, 1);


--
-- TOC entry 3456 (class 0 OID 26102)
-- Dependencies: 223
-- Data for Name: Customers; Type: TABLE DATA; Schema: public; Owner: flexbook
--

INSERT INTO public."Customers" ("Id") VALUES (8);
INSERT INTO public."Customers" ("Id") VALUES (13);
INSERT INTO public."Customers" ("Id") VALUES (14);


--
-- TOC entry 3450 (class 0 OID 26000)
-- Dependencies: 217
-- Data for Name: Orders; Type: TABLE DATA; Schema: public; Owner: flexbook
--

INSERT INTO public."Orders" ("Id", "UpdatedOn", "PaymentMethod", "Status", "TotalPrice", "CustomerId", "CreatedOn") VALUES (3, '2022-07-13 12:13:01.85874+03', 'COD', 'Pending', 37.510000000000005, 13, '2022-07-13 12:13:01.85874+03');
INSERT INTO public."Orders" ("Id", "UpdatedOn", "PaymentMethod", "Status", "TotalPrice", "CustomerId", "CreatedOn") VALUES (4, '2022-07-13 12:36:05.6183+03', 'COD', 'Pending', 32.86, 14, '2022-07-13 12:36:05.6183+03');
INSERT INTO public."Orders" ("Id", "UpdatedOn", "PaymentMethod", "Status", "TotalPrice", "CustomerId", "CreatedOn") VALUES (5, '2022-07-13 12:42:30.010032+03', 'Debit/Credit Card', 'Pending', 47.56, 14, '2022-07-13 12:42:30.010032+03');
INSERT INTO public."Orders" ("Id", "UpdatedOn", "PaymentMethod", "Status", "TotalPrice", "CustomerId", "CreatedOn") VALUES (6, '2022-07-13 12:48:11.015705+03', 'COD', 'Pending', 32.07, 14, '2022-07-13 12:48:11.015705+03');
INSERT INTO public."Orders" ("Id", "UpdatedOn", "PaymentMethod", "Status", "TotalPrice", "CustomerId", "CreatedOn") VALUES (7, '2022-07-13 12:50:41.234+03', 'COD', 'Pending', 26.36, 14, '2022-07-13 12:50:41.234+03');
INSERT INTO public."Orders" ("Id", "UpdatedOn", "PaymentMethod", "Status", "TotalPrice", "CustomerId", "CreatedOn") VALUES (8, '2022-07-13 15:32:09.160133+03', 'Paypal', 'Pending', 74.11, 8, '2022-07-13 15:32:09.160133+03');


--
-- TOC entry 3454 (class 0 OID 26024)
-- Dependencies: 221
-- Data for Name: OrderItems; Type: TABLE DATA; Schema: public; Owner: flexbook
--

INSERT INTO public."OrderItems" ("Id", "Quantity", "ProductId", "OrderId") VALUES (5, 2, 4, 3);
INSERT INTO public."OrderItems" ("Id", "Quantity", "ProductId", "OrderId") VALUES (6, 1, 6, 3);
INSERT INTO public."OrderItems" ("Id", "Quantity", "ProductId", "OrderId") VALUES (7, 1, 3, 4);
INSERT INTO public."OrderItems" ("Id", "Quantity", "ProductId", "OrderId") VALUES (8, 1, 4, 4);
INSERT INTO public."OrderItems" ("Id", "Quantity", "ProductId", "OrderId") VALUES (9, 1, 8, 4);
INSERT INTO public."OrderItems" ("Id", "Quantity", "ProductId", "OrderId") VALUES (10, 1, 6, 5);
INSERT INTO public."OrderItems" ("Id", "Quantity", "ProductId", "OrderId") VALUES (11, 1, 11, 5);
INSERT INTO public."OrderItems" ("Id", "Quantity", "ProductId", "OrderId") VALUES (12, 1, 12, 5);
INSERT INTO public."OrderItems" ("Id", "Quantity", "ProductId", "OrderId") VALUES (13, 2, 4, 6);
INSERT INTO public."OrderItems" ("Id", "Quantity", "ProductId", "OrderId") VALUES (14, 1, 3, 6);
INSERT INTO public."OrderItems" ("Id", "Quantity", "ProductId", "OrderId") VALUES (15, 1, 6, 7);
INSERT INTO public."OrderItems" ("Id", "Quantity", "ProductId", "OrderId") VALUES (16, 1, 4, 7);
INSERT INTO public."OrderItems" ("Id", "Quantity", "ProductId", "OrderId") VALUES (17, 3, 4, 8);
INSERT INTO public."OrderItems" ("Id", "Quantity", "ProductId", "OrderId") VALUES (18, 2, 5, 8);


--
-- TOC entry 3465 (class 0 OID 0)
-- Dependencies: 210
-- Name: Addresses_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: flexbook
--

SELECT pg_catalog.setval('public."Addresses_Id_seq"', 16, true);


--
-- TOC entry 3466 (class 0 OID 0)
-- Dependencies: 225
-- Name: BookReviews_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: flexbook
--

SELECT pg_catalog.setval('public."BookReviews_Id_seq"', 3, true);


--
-- TOC entry 3467 (class 0 OID 0)
-- Dependencies: 214
-- Name: Comments_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: flexbook
--

SELECT pg_catalog.setval('public."Comments_Id_seq"', 4, true);


--
-- TOC entry 3468 (class 0 OID 0)
-- Dependencies: 220
-- Name: OrderItems_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: flexbook
--

SELECT pg_catalog.setval('public."OrderItems_Id_seq"', 18, true);


--
-- TOC entry 3469 (class 0 OID 0)
-- Dependencies: 216
-- Name: Orders_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: flexbook
--

SELECT pg_catalog.setval('public."Orders_Id_seq"', 8, true);


--
-- TOC entry 3470 (class 0 OID 0)
-- Dependencies: 218
-- Name: Product_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: flexbook
--

SELECT pg_catalog.setval('public."Product_Id_seq"', 12, true);


--
-- TOC entry 3471 (class 0 OID 0)
-- Dependencies: 212
-- Name: User_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: flexbook
--

SELECT pg_catalog.setval('public."User_Id_seq"', 14, true);


-- Completed on 2022-07-14 10:27:39 EEST

--
-- PostgreSQL database dump complete
--

