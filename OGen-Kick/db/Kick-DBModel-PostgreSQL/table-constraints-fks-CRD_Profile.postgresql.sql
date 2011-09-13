ALTER TABLE "CRD_Profile"
  ADD CONSTRAINT "CRD_Profile_IFApplication_fkey" FOREIGN KEY ("IFApplication")
    REFERENCES "APP_Application" ("IDApplication") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

