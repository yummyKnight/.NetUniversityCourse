TRUNCATE table "Client" CASCADE;
TRUNCATE table "Booking" CASCADE;
TRUNCATE table "Payment" CASCADE;
TRUNCATE table "Room" CASCADE;
TRUNCATE table "RoomType" CASCADE;
insert into "Client" (full_name, address, orders_num)
values ('Vasya Petrov', 'Moskow', 1),
       ('Ilya Smoilov', 'SPB', 1);
insert into "RoomType" (room_type)
values (1);
insert into "RoomType" (room_type)
values (2);
insert into "RoomType" (room_type)
values (3);
insert into "RoomType" (room_type)
values (4);
insert into "RoomType" (room_type)
values (5);
INSERT into "Room" (room_type_id, price)
VALUES (1, 10000);
INSERT into "Room" (room_type_id, price)
VALUES (2, 50000);
INSERT into "Room" (room_type_id, price)
VALUES (3, 80000);
INSERT into "Room" (room_type_id, price)
VALUES (4, 100000);
INSERT into "Room" (room_type_id, price)
VALUES (5, 150000);
insert into "Booking" (client_id, room_id, reserved_day, check_in, check_out)
values (1, 1, date '2020-04-12', date '2020-04-16', date '2020-04-20');
insert into "Booking" (client_id, room_id, reserved_day, check_in, check_out)
values (1, 2, date '2020-05-10', date '2020-05-20', date '2020-05-25');
insert into "Booking" (client_id, room_id, reserved_day, check_in, check_out)
values (2, 3, date '2020-04-25', date '2020-05-17', date '2020-05-25');
insert into "Booking" (client_id, room_id, reserved_day, check_in, check_out)
values (2, 4, date '2020-05-26', date '2020-06-10', date '2020-06-20');
insert into "Payment" (booking_id, amount)
values (1, 100000);
insert into "Payment" (booking_id, amount)
values (2, 1000);
insert into "Payment" (booking_id, amount)
values (3, 5000);
insert into "Payment" (booking_id, amount)
values (4, 2000);