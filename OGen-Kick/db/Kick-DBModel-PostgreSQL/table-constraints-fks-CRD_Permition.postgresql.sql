ALTER TABLE "CRD_Permition"
  ADD CONSTRAINT "CRD_Permition_IFApplication_fkey" FOREIGN KEY ("IFApplication")
    REFERENCES "APP_Application" ("IDApplication") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

