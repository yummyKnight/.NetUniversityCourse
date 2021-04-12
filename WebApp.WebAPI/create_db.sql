CREATE TABLE "Client" (
  "id" SERIAL PRIMARY KEY,
  "full_name" varchar(255) NOT NULL,
  "address" varchar(255) NOT NULL,
  "orders_num" int,
  "created_at" date DEFAULT (now()),
  "modified_at" date DEFAULT (now())
);

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

CREATE TABLE "RoomType" (
  "id" SERIAL PRIMARY KEY,
  "room_type" varchar(150) UNIQUE NOT NULL
);

CREATE TABLE "Room" (
  "id" SERIAL PRIMARY KEY,
  "room_type_id" int,
  "price" unsigned NOT NULL
);

CREATE TABLE "Payment" (
  "id" SERIAL PRIMARY KEY,
  "booking_id" int,
  "amount" unsigned NOT NULL,
  "created_at" date DEFAULT (now()),
  "modified_at" date DEFAULT (now()),
  "payment_type_id" int,
  "canceled" bool DEFAULT false,
  "canceled_at" date
);

CREATE TABLE "PaymentType" (
  "id" SERIAL PRIMARY KEY,
  "type" varchar UNIQUE NOT NULL
);

ALTER TABLE "Booking" ADD FOREIGN KEY ("client_id") REFERENCES "Client" ("id");

ALTER TABLE "Booking" ADD FOREIGN KEY ("room_id") REFERENCES "Room" ("id");

ALTER TABLE "Room" ADD FOREIGN KEY ("room_type_id") REFERENCES "RoomType" ("id");

ALTER TABLE "Payment" ADD FOREIGN KEY ("booking_id") REFERENCES "Booking" ("id");

ALTER TABLE "Payment" ADD FOREIGN KEY ("payment_type_id") REFERENCES "PaymentType" ("id");

COMMENT ON COLUMN "Payment"."amount" IS 'In dollars';
