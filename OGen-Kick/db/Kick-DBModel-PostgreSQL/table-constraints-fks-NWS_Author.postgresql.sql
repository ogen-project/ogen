ALTER TABLE "NWS_Author"
  ADD CONSTRAINT "NWS_Author_IFApplication_fkey" FOREIGN KEY ("IFApplication")
    REFERENCES "APP_Application" ("IDApplication") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "NWS_Author_IFUser__Approved_fkey" FOREIGN KEY ("IFUser__Approved")
    REFERENCES "NET_User" ("IFUser") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

