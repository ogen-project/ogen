ALTER TABLE "NWS_UserTag"
  ADD CONSTRAINT "NWS_UserTag_IFUser_fkey" FOREIGN KEY ("IFUser")
    REFERENCES "NET_User" ("IFUser") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "NWS_UserTag_IFTag_fkey" FOREIGN KEY ("IFTag")
    REFERENCES "NWS_Tag" ("IDTag") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;
