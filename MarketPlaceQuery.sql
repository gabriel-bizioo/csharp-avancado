INSERT INTO Address (city, country, postal_code, state, street) 
VALUES 
  ('Ontario', 'Canada','487326','Upper Austria','830-1894 Odio. Avenue'),
  ('Paris', 'France','10-526','Guanajuato','464-8453 Mi Rd.'),
  ('Medellin', 'Colombia','3545','North Island','4579 Nunc. Street'),
  ('Wellington', 'New Zealand','67-23','Newfoundland and Labrador','Ap #571-3282 Eu Avenue'),
  ('Ciudad Del Mexico', 'Mexico','71-16','Eastern Cape','919-7123 Eu St.'),
  ('Toronto', 'Canada','66913','Overijssel','940-5527 Metus. Avenue'),
  ('New York', 'United States','Y2X 4E7','San José','P.O. Box 930, 1332 Rutrum Road'),
  ('Manila','Philippines','68-273','Eastern Visayas','869-3787 Ut Road'),
  ('Warsaw', 'Poland','17666-788','East Region','P.O. Box 818, 9707 Erat Road'),
  ('Roma','Italy','702315','Innlandet','564-9777 Mauris St.');

INSERT INTO Client (addressID, [document], email, login, name, passwd, phone)
VALUES
  (1,'846','non.lobortis@google.ca','nonummy.','Jana Vang','nonummy','(208) 533-6834'),
  (2,'978','erat.in@icloud.net','parturient','Craig Whitehead','et,','1-568-962-5011'),
  (3,'464','metus.aliquam@aol.org','consectetuer','Larissa Dawson','Fusce','(974) 829-6826'),
  (4,'474','magna@icloud.org','Cras','Wallace Guzman','molestie','1-111-510-2883'),
  (5,'242','mauris.blandit.mattis@hotmail.net','ac','Holly Dillard','enim','(692) 304-5857');


INSERT INTO Owner (addressID, [document], email, login, name, passwd, phone)
VALUES
  (1,'812','lorem.lorem@hotmail.com','mi','Wesley Silva','et','1-723-667-9717'),
  (2,'845','sed.leo@yahoo.edu','ut','Troy Ortiz','ut,','(207) 213-7945'),
  (3,'782','nunc@outlook.org','lacus.','Odysseus Slater','dui.','(238) 669-1952'),
  (4,'567','at.arcu@hotmail.edu','eget','Brady Collier','erat','(860) 123-4452'),
  (5,'445','viverra.donec.tempus@aol.org','libero','Ronan Carrillo','tincidunt','1-365-264-2746');


INSERT INTO Store (cnpj, name, ownerID)
VALUES
  ('862222','Luctus Ut Pellentesque Industries',1),
  ('8857','Viverra Maecenas Limited',2),
  ('474565','Ut LLC',3),
  ('8357','Pede Sagittis PC',4),
  ('06768','Sed Hendrerit Associates',5);

INSERT INTO Product (bar_code, img_link, name)
VALUES
  ('GHS88YUQ1JT','https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fpost.greatist.com%2Fwp-content%2Fuploads%2Fsites%2F3%2F2020%2F02%2F322868_1100-800x825.jpg&f=1&nofb=1','semper auctor.'),
  ('CVD32KVE7PS','https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fpost.greatist.com%2Fwp-content%2Fuploads%2Fsites%2F3%2F2020%2F02%2F322868_1100-800x825.jpg&f=1&nofb=1','aliquet magna'),
  ('LBB28HIS6IB','https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fpost.greatist.com%2Fwp-content%2Fuploads%2Fsites%2F3%2F2020%2F02%2F322868_1100-800x825.jpg&f=1&nofb=1','Donec tempus,'),
  ('BKJ22ZDL5YA','https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fpost.greatist.com%2Fwp-content%2Fuploads%2Fsites%2F3%2F2020%2F02%2F322868_1100-800x825.jpg&f=1&nofb=1','adipiscing fringilla,'),
  ('WYJ67NSV3BJ','https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fpost.greatist.com%2Fwp-content%2Fuploads%2Fsites%2F3%2F2020%2F02%2F322868_1100-800x825.jpg&f=1&nofb=1','quis, pede.');

INSERT INTO Stocks (productID,quantity,storeID,unit_price)
VALUES
  (1,5,1,10),
  (2,16,2,48),
  (3,19,3,20),
  (4,2,4,38),
  (5,4,5,39);

INSERT INTO WishList(ClientID,StockID)
VALUES
  (1,1),
  (2,2),
  (3,3),
  (4,4),
  (5,5);

INSERT INTO Purchase(Payment,PurchaseStatus,ClientID,productID,purchase_date,purchase_value,storeID)
VALUES
  (0,1,1,1,'2023-05-07 12:52:54',49,1),
  (1,1,2,2,'2021-09-18 09:22:13',19,2),
  (2,0,3,3,'2021-11-08 19:33:41',45,3),
  (0,1,4,4,'2022-06-18 04:53:52',48,4),
  (1,1,5,5,'2022-11-20 23:00:20',42,5);