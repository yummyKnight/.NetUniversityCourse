DROP TABLE IF EXISTS "Client" CASCADE;
CREATE TABLE "Client" (
                          "id" SERIAL PRIMARY KEY,
                          "full_name" varchar(255) NOT NULL,
                          "address" varchar(255) NOT NULL,
                          "orders_num" int,
                          "created_at" date DEFAULT (now()),
                          "modified_at" date DEFAULT (now())
);
DROP TABLE IF EXISTS "Booking" CASCADE;
CREATE TABLE "Booking" (
                           "id" SERIAL PRIMARY KEY,
                           "client_id" int,
                           "room_id" int,
                           "reserved_day" date NOT NULL,
                           "check_in" date NOT NULL,
                           "check_out" date NOT NULL,
                           "is_canceled" bool DEFAULT false,
                           "canceled_at" date,
                           "created_at" date DEFAULT (now()),
                           "modified_at" date DEFAULT (now())
);
DROP TABLE IF EXISTS "RoomType" CASCADE;
CREATE TABLE "RoomType" (
                            "id" SERIAL PRIMARY KEY,
                            "room_type" varchar(150) UNIQUE NOT NULL
);
DROP TABLE IF EXISTS "Room" CASCADE;
CREATE TABLE "Room" (
                        "id" SERIAL PRIMARY KEY,
                        "room_type_id" int,
                        "price" int NOT NULL
);
DROP TABLE IF EXISTS "Payment" CASCADE;
CREATE TABLE "Payment" (
                           "id" SERIAL PRIMARY KEY,
                           "booking_id" int,
                           "amount" int NOT NULL,
                           "created_at" date DEFAULT (now()),
                           "modified_at" date DEFAULT (now()),
                           "payment_type_id" int,
                           "canceled" bool DEFAULT false,
                           "canceled_at" date
);
ALTER TABLE "Booking" ADD FOREIGN KEY ("client_id") REFERENCES "Client" ("id");

ALTER TABLE "Booking" ADD FOREIGN KEY ("room_id") REFERENCES "Room" ("id");

ALTER TABLE "Room" ADD FOREIGN KEY ("room_type_id") REFERENCES "RoomType" ("id");

ALTER TABLE "Payment" ADD FOREIGN KEY ("booking_id") REFERENCES "Booking" ("id");

COMMENT ON COLUMN "Payment"."amount" IS 'In dollars';
