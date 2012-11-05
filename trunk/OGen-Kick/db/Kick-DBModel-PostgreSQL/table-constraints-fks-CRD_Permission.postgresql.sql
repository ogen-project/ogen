ALTER TABLE "CRD_Permission"
  ADD CONSTRAINT "CRD_Permission_IFApplication_fkey" FOREIGN KEY ("IFApplication")
    REFERENCES "APP_Application" ("IDApplication") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "CRD_Permission_IFTable_fkey" FOREIGN KEY ("IFTable")
    REFERENCES "CRD_Table" ("IDTable") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "CRD_Permission_IFAction_fkey" FOREIGN KEY ("IFAction")
    REFERENCES "CRD_Action" ("IDAction") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;
