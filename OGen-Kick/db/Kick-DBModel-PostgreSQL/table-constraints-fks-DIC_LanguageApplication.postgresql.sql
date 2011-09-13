ALTER TABLE "DIC_LanguageApplication"
  ADD CONSTRAINT "DIC_LanguageApplication_IFLanguage_fkey" FOREIGN KEY ("IFLanguage")
    REFERENCES "DIC_Language" ("IDLanguage") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION,
  ADD CONSTRAINT "DIC_LanguageApplication_IFApplication_fkey" FOREIGN KEY ("IFApplication")
    REFERENCES "APP_Application" ("IDApplication") MATCH SIMPLE
    ON UPDATE NO ACTION ON DELETE NO ACTION
;

