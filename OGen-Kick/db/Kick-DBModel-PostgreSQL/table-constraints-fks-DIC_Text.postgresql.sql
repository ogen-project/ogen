ALTER TABLE "DIC_Text"
  ADD CONSTRAINT "DIC_Text_IFApplication_fkey" FOREIGN KEY ("IFApplication")
    REFERENCES "APP_Application" ("IDApplication") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

