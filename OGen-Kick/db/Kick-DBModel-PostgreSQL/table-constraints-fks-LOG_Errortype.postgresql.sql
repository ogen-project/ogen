ALTER TABLE "LOG_Errortype"
  ADD CONSTRAINT "LOG_Errortype_IFApplication_fkey" FOREIGN KEY ("IFApplication")
    REFERENCES "APP_Application" ("IDApplication") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

