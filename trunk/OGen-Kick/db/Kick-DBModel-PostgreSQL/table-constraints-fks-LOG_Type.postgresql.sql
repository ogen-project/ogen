ALTER TABLE "LOG_Type"
  ADD CONSTRAINT "LOG_Type_IFApplication_fkey" FOREIGN KEY ("IFApplication")
    REFERENCES "APP_Application" ("IDApplication") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "LOG_Type_IFType_parent_fkey" FOREIGN KEY ("IFType_parent")
    REFERENCES "LOG_Type" ("IDType") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

