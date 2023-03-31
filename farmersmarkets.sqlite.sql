BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "ContactInfo" (
	"Id"	INTEGER NOT NULL UNIQUE,
	"Phone"	INTEGER,
	"Address"	TEXT,
	"Email"	TEXT,
	"Website"	TEXT,
	PRIMARY KEY("Id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "FarmersMarket" (
	"Id"	INTEGER UNIQUE,
	"IsSnapFriendly"	INTEGER,
	"Name"	TEXT NOT NULL,
	"Contact"	INTEGER,
	FOREIGN KEY("Contact") REFERENCES "ContactInfo"("Id"),
	PRIMARY KEY("Id" AUTOINCREMENT)
);
COMMIT;