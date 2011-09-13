ALTER TABLE "FOR_Message"
  ADD CONSTRAINT "FOR_Message_IFMessage__parent_fkey" FOREIGN KEY ("IFMessage__parent")
    REFERENCES "FOR_Message" ("IDMessage") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "FOR_Message_IFUser__Publisher_fkey" FOREIGN KEY ("IFUser__Publisher")
    REFERENCES "NET_User" ("IFUser") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "FOR_Message_IFApplication_fkey" FOREIGN KEY ("IFApplication")
    REFERENCES "APP_Application" ("IDApplication") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

