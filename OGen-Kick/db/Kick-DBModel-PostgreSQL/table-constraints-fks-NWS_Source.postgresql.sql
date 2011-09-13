ALTER TABLE "NWS_Source"
  ADD CONSTRAINT "NWS_Source_IFApplication_fkey" FOREIGN KEY ("IFApplication")
    REFERENCES "APP_Application" ("IDApplication") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "NWS_Source_IFSource__parent_fkey" FOREIGN KEY ("IFSource__parent")
    REFERENCES "NWS_Source" ("IDSource") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "NWS_Source_IFUser__Approved_fkey" FOREIGN KEY ("IFUser__Approved")
    REFERENCES "NET_User" ("IFUser") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

