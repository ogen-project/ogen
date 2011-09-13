ALTER TABLE "LOG_Logtype"
  ADD CONSTRAINT "LOG_Logtype_IFApplication_fkey" FOREIGN KEY ("IFApplication")
    REFERENCES "APP_Application" ("IDApplication") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "LOG_Logtype_IFLogtype_parent_fkey" FOREIGN KEY ("IFLogtype_parent")
    REFERENCES "LOG_Logtype" ("IDLogtype") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

