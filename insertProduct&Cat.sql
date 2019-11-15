CREATE TABLE Account (
idAccount VARCHAR(10) NOT NULL,
passwordAccount VARCHAR(50) NOT NULL,
nameUser NVARCHAR(50) NOT NULL,
phoneNum VARCHAR(11) NOT NULL,
PRIMARY KEY (idAccount)
);
INSERT INTO account VALUES ('an.nd',123,N'Ân Nguyễn','0123456789');
INSERT INTO account VALUES ('kiet.pa',321,N'Kiệt Phi','9876543210');

select * from account

create table Category (
	idCat int not null auto_increment,
    nameCat nvarchar(20),
    primary key (idCat)
);

select * from category

insert into category values (null, 'Coffee');
insert into category values (null, 'Ice Blend');
insert into category values (null, 'Fruit Tea');
insert into category values (null, 'Smoothie');
insert into category values (null, 'Macchiato');
insert into category values (null, 'Others');
insert into category values (null, 'Topping');
insert into category values (null, 'Snack');

create table ProductTopping(
	idPT int not null auto_increment,
    idProduct int,
    idTopping int,
    primary key (idPT),
    foreign key (idProduct) references Product (idProduct),
    foreign key (idTopping) references Product (idProduct)
);
select * from producttopping;
insert into producttopping values (null, 7, 46);
insert into producttopping values (null, 8, 46);
insert into producttopping values (null, 9, 46);
insert into producttopping values (null, 10, 46);
insert into producttopping values (null, 11, 46);
insert into producttopping values (null, 12, 46);
insert into producttopping values (null, 13, 46);
insert into producttopping values (null, 14, 46);
insert into producttopping values (null, 17, 46);
insert into producttopping values (null, 18, 46);
insert into producttopping values (null, 27, 47);
insert into producttopping values (null, 29,49);
insert into producttopping values (null, 30,48);
insert into producttopping values (null, 31,49);
insert into producttopping values (null, 32,49);
insert into producttopping values (null, 33,50);
insert into producttopping values (null, 34,50);
insert into producttopping values (null, 35,51);
insert into producttopping values (null, 35,52);
insert into producttopping values (null, 36,52);
insert into producttopping values (null, 39,51);
insert into producttopping values (null, 39,48);
insert into producttopping values (null, 40,51);
insert into producttopping values (null, 40,48);
insert into producttopping values (null, 41,51);
insert into producttopping values (null, 41,48);


select idProduct, nameProduct, priceProduct, imgProduct
from product 
where idProduct in (select b.idTopping
from product a, producttopping b
where a.idProduct=b.idProduct and a.idProduct=41 );

SELECT * FROM product ORDER BY idProduct DESC LIMIT 1;
select * from product;
select * from producttopping;
delete from producttopping where idProduct = 85;
create table Product (
	idProduct int not null auto_increment,
    idCat int not null,
    nameProduct nvarchar(30),
    priceSmallProduct int,
    priceMediumProduct int,
    priceLargeProduct int,
    priceProduct int,
    descriptionProduct nvarchar(1000),
    primary key (idProduct),
    foreign key (idCat) references category (idCat)
);
insert into product values (null, 1, N'Cold Brew Phúc Bồn Tử', null, 50000, 55000, null, N'Vị chua ngọt của trái phúc bồn tử, làm dậy lên hương vị trái cây tự nhiên vốn sẵn có trong hạt cà phê, hòa quyện thêm vị đăng đắng, ngọt dịu nhẹ nhàng của Cold Brew mang đến cách thưởng thức cà phê hoàn toàn mới và đầy thú vị.');
insert into product values (null, 1, N'Cold Brew Cam Sả', null, 50000, 55000, null, N'Tươi mát - Mượt mà, là sự kết hợp đầy mới mẻ khi hương vị của cam và sả được cân bằng trên nền của những nốt hương cà phê pha lạnh.');
insert into product values (null, 1, N'Cold Brew Sữa Tươi', null, 45000, 50000, null, N'Thanh mát và cân bằng với hương vị cà phê nguyên bản 100% arabica Cầu Đất cùng sữa tươi thơm béo cho từng ngụm tròn vị, hấp dẫn.');
insert into product values (null, 1, N'Cold Brew Truyền Thống', null, 45000, 50000, null, N'Nguyên bản và Tươi mới với hương gỗ thông, hạt dẻ, nốt sô cô la đặc trưng, hương khói nhẹ của hạt Arabica Cầu Đất');
insert into product values (null, 1, N'Cà phê sữa nóng', null, null, null, 35000, N'Cà phê phin kết hợp cùng sữa đặc là một sáng tạo đầy tự hào của người Việt, được xem là món uống thương hiệu của Việt Nam');
insert into product values (null, 1, N'Cà phê sữa đá', 29000, 35000, 39000, null, N'Cà phê phin kết hợp cùng sữa đặc là một sáng tạo đầy tự hào của người Việt, được xem là món uống thương hiệu của Việt Nam');
insert into product values (null, 1, N'Caramel Macchiato Đá', 50000, 55000, null, null, N'Vị thơm béo của bọt sữa và sữa tươi, vị đắng thanh thoát của cà phê Espresso hảo hạng, và vị ngọt đậm của sốt caramel.');
insert into product values (null, 1, N'Caramel Macchiato Nóng', 50000, 55000, null, null, N'Vị thơm béo của bọt sữa và sữa tươi, vị đắng thanh thoát của cà phê Espresso hảo hạng, và vị ngọt đậm của sốt caramel.');
insert into product values (null, 1, N'Americano Nóng', 40000, 45000, null, null, N'Americano được pha chế bằng cách thêm nước vào một hoặc hai shot Espresso để pha loãng độ đặc của cà phê, từ đó mang lại hương vị nhẹ nhàng, không gắt mạnh và vẫn thơm nồng nàn.');
insert into product values (null, 1, N'Americano Đá', 40000, 45000, null, null, N'Americano được pha chế bằng cách thêm nước vào một hoặc hai shot Espresso để pha loãng độ đặc của cà phê, từ đó mang lại hương vị nhẹ nhàng, không gắt mạnh và vẫn thơm nồng nàn.');
insert into product values (null, 1, N'Cappucino Nóng', 50000, 55000, null, null, N'Cappucino được gọi vui là thức uống "một - phần - ba" - 1/3 Espresso, 1/3 Sữa nóng, 1/3 Foam.');
insert into product values (null, 1, N'Cappucino Đá', 50000, 55000, null, null, N'Cappucino được gọi vui là thức uống "một - phần - ba" - 1/3 Espresso, 1/3 Sữa nóng, 1/3 Foam.');
insert into product values (null, 1, N'Latte Nóng', 50000, 55000, null, null, N'Khi chuẩn bị Latte, cà phê Espresso và sữa nóng được trộn lẫn vào nhau, bên trên vẫn là lợp foam nhưng mỏng và nhẹ hơn Cappucino.');
insert into product values (null, 1, N'Latte Đá', 50000, 55000, null, null, N'Khi chuẩn bị Latte, cà phê Espresso và sữa nóng được trộn lẫn vào nhau, bên trên vẫn là lợp foam nhưng mỏng và nhẹ hơn Cappucino.');
insert into product values (null, 1, N'Mocha Nóng', 50000, 55000, null, null, N'Cà phê Mocha được ví von đơn giản là Sốt Sô cô la được pha cùng một tách Espresso.');
insert into product values (null, 1, N'Mocha Đá', 50000, 55000, null, null, N'Cà phê Mocha được ví von đơn giản là Sốt Sô cô la được pha cùng một tách Espresso.');
insert into product values (null, 1, N'Espresso Đá', 45000, null, null, null, N'Cà phê máy sử dụng tỷ lệ trộn 70% Arabica và 30% Robusta, cà phê nguyên chất chiết xuất từ máy dưới áp suất cao, hương thơm mạnh và chua nhẹ từ hạt, vị đậm đà của hạt robusta, hàm lượng cafein thấp do tính chất của hạt Arabica.');
insert into product values (null, 1, N'Espresso Nóng', 40000, null, null, null, N'Cà phê máy sử dụng tỷ lệ trộn 70% Arabica và 30% Robusta, cà phê nguyên chất chiết xuất từ máy dưới áp suất cao, hương thơm mạnh và chua nhẹ từ hạt, vị đậm đà của hạt robusta, hàm lượng cafein thấp do tính chất của hạt Arabica.');
insert into product values (null, 1, N'Cà Phê Đen Nóng', null, null, null, 35000, N'Một tách cà phê đen thơm ngào ngạt, phảng phát mùi cacao là món quà tự thưởng tuyệt vời nhất cho những ai mê đắm tính chất nguyên bản nhất của cà phê. Một tách cà phê trầm lắng, thi vị giữa dòng đời vồn vã.');
insert into product values (null, 1, N'Cà Phê Đen Đá', 29000, 35000, 39000, null, N'Một tách cà phê đen thơm ngào ngạt, phảng phát mùi cacao là món quà tự thưởng tuyệt vời nhất cho những ai mê đắm tính chất nguyên bản nhất của cà phê. Một tách cà phê trầm lắng, thi vị giữa dòng đời vồn vã.');
insert into product values (null, 1, N'Bạc Xỉu Nóng', null, null, null, 35000, N'Theo chân những người gốc Hoa đến định cư tại Sài Gòn, Bạc sỉu là cách gọi tắt của "Bạc tẩy xỉu phé" trong tiếng Quảng Đông, chính là: Ly sữa trắng kèm một chút cà phê.');
insert into product values (null, 1, N'Bạc Xỉu', 29000, 35000, 39000, null, N'Theo chân những người gốc Hoa đến định cư tại Sài Gòn, Bạc sỉu là cách gọi tắt của "Bạc tẩy xỉu phé" trong tiếng Quảng Đông, chính là: Ly sữa trắng kèm một chút cà phê.');



insert into product values (null, 2, N'Phúc Bồn Tử Cam Đá Xay', null, 59000, 65000, null, N'Tê tái ngay đầu lưỡi bởi sự mát lạnh của đá xay. Hòa quyện thêm hương vị chua chua, ngọt ngọt từ trái cam tươi và trái phúc bồn tử 100% tự nhiên, để cho ra một hương vị thanh mát, kích thích vị giác đầy thú vị ngay từ lần đầu thưởng thức.');
insert into product values (null, 2, N'Chanh Sả Đá Xay', null, 49000, 55000, null, N'Sự kết hợp giữa chanh, sả thơm lừng và đá đem lại cảm giác mát lạnh xua tán nóng bức của mùa hè.');
insert into product values (null, 2, N'Matcha Đá Xay', null, 59000, 65000, null, N'Matcha thanh, nhẫn, và đắng nhẹ được nhân đôi sảng khoái khi uống lạnh. Nhấn nhá thêm những nét bùi béo của kem và sữa. Gây thương nhớ vô cùng!');
insert into product values (null, 2, N'Cookie Đá Xay', null, 59000, 65000, null, N'Những mẩu bánh cookies giòn rụm kết hợp ăn ý với sữa tươi và kem tươi béo ngọt, đem đến cảm giác lạ miệng gây thích thú. Một món uống phá cách dễ thương.');
insert into product values (null, 2, N'Chocolate Đá Xay', null, 59000, 65000, null, N'Sữa và kem tươi béo ngọt được "cá tính hóa" bởi vị chocolate đăng đắng. Dành cho các tín đồ hảo ngọt. Lựa chọn hàng đầu nếu bạn đang cần chút năng lượng tinh thần để thúc đẩy nhịp sống.');
insert into product values (null, 2, N'Ổi Hồng Việt Quất Đá Xay', null, 59000, 65000, null, N'Hương ổi ngọt tự nhiên và thanh mát, được khéo léo "xuyến" nhẹ thêm những tầng hương của mùa hè dịu mát: cam, lớp mixed berry, whipping cream.');
insert into product values (null, 2, N'Đào Việt Quất Đá Xay', null, 59000, 65000, null, N'Vẫn vị đào quen thuộc nhưng được khoác lên mình một vẻ đầy thanh mát và giải khát hơn.');

insert into product values (null, 3, N'Trà Phúc Bồn Tử', 49000, 55000, 59000, null, N'Lần đầu tiên trà Oolong và trái Phúc Bồn Tử hoàn toàn tự nhiên, được kết hợp để tạo ra một dư vị hoàn toàn tươi mới. Nhấp ngay một ngụm là thấy mát lạnh ngay tức khắc, đọng lại mãi nơi cuốn họng là hương vị trà thơm lừng và vị ngọt thanh, chua dịu khó quên của trái phúc bồn tử.');
insert into product values (null, 3, N'Trà Đào Cam Sả - Đá', 45000, 52000, 59000, null, N'Vị thanh ngọt của đào Hy Lạp, vị chua dịu của Cam Vàng nguyên vỏ, vị chát của trà đen tươi được ủ mới mỗi 4 tiếng, cùng hương thơm nồng đặc trưng của sả chính là điểm sáng làm nên sức hấp dẫn của thức uống này.');
insert into product values (null, 3, N'Trà Đào Cam Sả - Nóng', null, null, null, 59000, N'Vị thanh ngọt của đào Hy Lạp, vị chua dịu của Cam Vàng nguyên vỏ, vị chát của trà đen tươi được ủ mới mỗi 4 tiếng, cùng hương thơm nồng đặc trưng của sả chính là điểm sáng làm nên sức hấp dẫn của thức uống này.');
insert into product values (null, 3, N'Oolong Vải Như Ý - Đá', 45000, 52000, 59000, null, N'Là sự kết hợp của trà Oolong và trái vải quen thuộc. Là món uống thanh mát, dịu nhẹ rất dễ sử dụng bởi sự hòa quyện của vị chua thanh của vải, hậu vị ngọt kéo dài của trà oolong. Ngoài ra trong mỗi ly nước còn có vị trà nhẹ nhàng vừa phải, có thể dùng được cho cả buổi sáng và chiều tối.');
insert into product values (null, 3, N'Oolong Vải Như Ý - Nóng', null, null, null, 59000, N'Là sự kết hợp của trà Oolong và trái vải quen thuộc. Nhâm nhi từng ngụm trà nóng khách hàng sẽ trải nghiệm trọn vẹn hơn mùi thơm dậy của vải. Vị ngọt thanh, chua nhẹ của sản phẩm vẫn được giữ nguyên rất dễ uống. Sản phẩm có vị trà nhẹ nhàng vừa phải, có thể dùng được cho cả buổi sáng và chiều tối.');
insert into product values (null, 3, N'Oolong Sen An Nhiên - Đá', 45000, 52000, 59000, null, N'Trà Oolong và hạt sen đều là những thành phần tốt cho sức khỏe với công dụng thanh lọc cơ thể, giải nhiệt và làm đẹp. Trà Oolong Sen An Nhiên có vị thanh mát của trà và sen, vị ngọt dịu kết hợp cùng chút béo thơm của cream cheese và hạt sen tươi mềm ăn kèm. Sản phẩm có vị trà nhẹ vừa phải.');
insert into product values (null, 3, N'Oolong Sen An Nhiên - Nóng', null, null, null, 59000, N'Trà Oolong sen nóng sẽ dậy hơn mùi thơm của trà và hạt sen. Trà có vị ngọt dịu nhẹ, rất tốt cho sức khỏe và giúp giữ ấm cơ thể. Sản phẩm có vị trà nhẹ nhàng vừa phải, có thể dùng được cho cả buổi sáng và chiều tối.');

insert into product values (null, 4, N'Sinh Tố Cam Xoài', null, null, null, 59000, N'Vị mứt cam xoài hòa trộn độc đáo với sữa chua, cho cảm giac chua ngọt rất sướng. Điểm nhấn là những mẩu bánh cookie giòn tan giúp sự thưởng thức thêm thú vị.');
insert into product values (null, 4, N'Sinh Tố Việt Quất', null, null, null, 59000, N'Mứt Việt Quất chua thanh, ngòn ngọt, phối hợp nhịp nhàng với dòng sữa chua bổ dưỡng. Là món sinh tố thơm ngon mà cả đầu lưỡi và làn da đều thích.');

insert into product values (null, 5, N'Matcha Macchiato', 42000, 48000, 55000, null, N'Bột trà xanh Matcha thơm lừng hảo hạng cùng lớp Macchiato béo ngậy là một sự kết hợp tuyệt vời.');
insert into product values (null, 5, N'Trà Gạo Rang Macchiato', 45000, 52000, 59000, null, N'Trà gạo rang, hay còn gọi là Genmaicha, hay Trà xanh gạo lựt có nguồn gốc từ Nhật Bản. Tại The Coffee House, chúng tôi nhấn nhá cho Genmaicha thêm lớp Macchiato để tăng thêm mùi vị cũng như trải nghiệm của chính bạn.');
insert into product values (null, 5, N'Trà Đen Macchiato', 42000, 45000, 55000, null, N'Trà đen được ủ mới mỗi ngày, giữ nguyên được vị chát mạnh mẽ và đặc trưng của lá trà, phủ bên trên là lớp Maccchiato "homemade" bồng bềnh quyến rũ vị phô mai mặn mặn mà béo béo.');

insert into product values (null, 6, N'Trà Matcha Latte Đá', null, null, null, 59000, N'Với màu xanh mát mắt của bột trà Matcha, vị ngọt nhẹ nhàng, pha trộn cùng sữa tươi và lớp foam mềm mịn, Matcha Latte là thức uống yêu thích của tất cả mọi người khi ghé The Coffee House.');
insert into product values (null, 6, N'Trà Matcha Latte Nóng', null, null, null, 59000, N'Với màu xanh mát mắt của bột trà Matcha, vị ngọt nhẹ nhàng, pha trộn cùng sữa tươi và lớp foam mềm mịn, Matcha Latte là thức uống yêu thích của tất cả mọi người khi ghé The Coffee House.');
insert into product values (null, 6, N'Chocolate Đá', null, null, null, 59000, N'Chocolate.');
insert into product values (null, 6, N'Chocolate Nóng', null, null, null, 59000, N'Chocolate.'); 

insert into product values (null, 7, N'Espresso (1shot)', null, null, null, 10000, null);
insert into product values (null, 7, N'Sauce Chocolate', null, null, null, 10000, null);
insert into product values (null, 7, N'Trân châu trắng', null, null, null, 10000, null);
insert into product values (null, 7, N'Đào ngâm', null, null, null, 10000, null);
insert into product values (null, 7, N'Vải ngâm', null, null, null, 10000, null);
insert into product values (null, 7, N'Extra foam', null, null, null, 10000, null);
insert into product values (null, 7, N'Sen ngâm', null, null, null, 10000, null);

insert into product values (null, 8, N'Bánh Mì Que - Cay', null, null, null, 10000, N'Bánh mì que.');
insert into product values (null, 8, N'Bánh Mì Que - Không Cay', null, null, null, 10000, N'Bánh mì que.');
insert into product values (null, 8, N'Đậu Phộng Tỏi Ớt', null, null, null, 10000, N'Đậu phộng béo được áo thêm lớp tỏi ớt mặn mặn, ngọt ngọt và chút cay cay. Vừa nhâm nhi với trà hay món nước mát lạnh nữa là đúng bài, ăn hoài không ngán.');
insert into product values (null, 8, N'Khô Gà Lá Chanh', null, null, null, 20000, N'Thịt gà được xé tơi, vị mặn, ngọt và cay quyện nhau vừa chuẩn, thêm chút thơm thơm từ lá chanh sấy khô giòn giòn nữa thì cơn buồn miệng nào cũng sẽ bị xua tan.');
insert into product values (null, 8, N'Điều Vàng Rang Muối', null, null, null, 20000, N'Hạt điều vị vừa bùi, vừa mặn được rang với tỉ lệ được cân chỉnh để vẫn giữ được độ giòn.');
insert into product values (null, 8, N'Khô Gà Bơ Cay', null, null, null, 20000, N'Khô gà bơ cay với vị mặn, cay và thơm vừa chuẩn cho cả buổi hẹn hò của bạn thêm "mặn" mà xôm tụ.');
insert into product values (null, 8, N'Hạt Sen Sấy', null, null, null, 30000, N'Hạt sen vừa thơm ngon bổ dưỡng, vừa cho vị ngọt bùi và giòn thơm. Kết hợp với những món uống thanh mát và tự nhiên của Nhà thì không còn gì để bàn cãi nữa đúng không?');
insert into product values (null, 8, N'Cơm Cháy Chà Bông', null, null, null, 25000, N'Cơm cháy giòn rụm, phủ lên lớp nước sốt ớt vừa mặ vừa cay cùng chà bông cho hương vị thơm ngon xuất sắc.');
insert into product values (null, 8, N'Gạo Lứt Sấy Giòn', null, null, null, 10000, N'Gạo lứt giàu dinh dưỡng và cực ngon được rang theo nhiệt độ hợp lí để giữ nguyên hương vị thuần túy và các khoáng chất tốt cho sức khỏe.');


select * from category;
delete from producttopping where idProduct=66;

select *
from category a, product b
where a.idCat = b.idCa

select * from product;
select * from category
ALTER TABLE account ADD COLUMN role nvarchar(10);

ALTER TABLE product ADD column rate int NOT NULL DEFAULT 1

select t.idProduct, t.rate 
from product t
join (select max(rate) as mxitem from product) x
on x.mxitem = t.rate

create table Bill (
	idBill int not null auto_increment,
    idAccount VARCHAR(10) not null,
    idxTable int,
    dateBill date,
    statusBill bool,
    primary key (idBill),
    foreign key (idAccount) references account (idAccount)
);

create table DetailBill(
	idDetailBill int not null auto_increment,
    idBill int not null,
    idProduct int not null,
    quantity int,
    price int,
    primary key (idDetailBill),
    foreign key (idBill) references Bill (idBill),
    foreign key (idProduct) references Product (idProduct)
);