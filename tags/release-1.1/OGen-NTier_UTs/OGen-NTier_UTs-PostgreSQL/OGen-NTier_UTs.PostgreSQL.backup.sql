--
-- PostgreSQL database dump
--

-- Started on 2006-04-14 21:01:04 GMT Standard Time

SET client_encoding = 'UTF8';
SET check_function_bodies = false;
SET client_min_messages = warning;

--
-- TOC entry 1610 (class 1262 OID 17868)
-- Name: OGen-NTier_UTs; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "OGen-NTier_UTs" WITH TEMPLATE = template0 ENCODING = 'UTF8';


ALTER DATABASE "OGen-NTier_UTs" OWNER TO postgres;

\connect "OGen-NTier_UTs"

SET client_encoding = 'UTF8';
SET check_function_bodies = false;
SET client_min_messages = warning;

--
-- TOC entry 1611 (class 0 OID 0)
-- Dependencies: 4
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON SCHEMA public IS 'Standard public schema';


--
-- TOC entry 314 (class 2612 OID 16386)
-- Name: plpgsql; Type: PROCEDURAL LANGUAGE; Schema: -; Owner: 
--

CREATE PROCEDURAL LANGUAGE plpgsql;


SET search_path = public, pg_catalog;

--
-- TOC entry 24 (class 1255 OID 17919)
-- Dependencies: 314 4
-- Name: fnc0_Config_isObject(character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "fnc0_Config_isObject"("Name_" character varying) RETURNS boolean
    AS $$
	BEGIN
		RETURN EXISTS(
			SELECT
				true -- whatever, just checking existence
			FROM "Config"
			WHERE
				("Name" = "Name_")
		);
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."fnc0_Config_isObject"("Name_" character varying) OWNER TO postgres;

--
-- TOC entry 26 (class 1255 OID 17920)
-- Dependencies: 314 4
-- Name: fnc0_Group_isObject(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "fnc0_Group_isObject"("IDGroup_" bigint) RETURNS boolean
    AS $$
	BEGIN
		RETURN EXISTS(
			SELECT
				true -- whatever, just checking existence
			FROM "Group"
			WHERE
				("IDGroup" = "IDGroup_")
		);
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."fnc0_Group_isObject"("IDGroup_" bigint) OWNER TO postgres;

--
-- TOC entry 28 (class 1255 OID 17922)
-- Dependencies: 4 314
-- Name: fnc0_UserGroup_isObject(bigint, bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "fnc0_UserGroup_isObject"("IDUser_" bigint, "IDGroup_" bigint) RETURNS boolean
    AS $$
	BEGIN
		RETURN EXISTS(
			SELECT
				true -- whatever, just checking existence
			FROM "UserGroup"
			WHERE
				("IDUser" = "IDUser_") AND
				("IDGroup" = "IDGroup_")
		);
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."fnc0_UserGroup_isObject"("IDUser_" bigint, "IDGroup_" bigint) OWNER TO postgres;

--
-- TOC entry 58 (class 1255 OID 17959)
-- Dependencies: 4 314
-- Name: fnc0_User_Record_count_all(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "fnc0_User_Record_count_all"() RETURNS bigint
    AS $$
	DECLARE
		_Output int8 = 0;
	BEGIN
		SELECT
			COUNT("IDUser")
		INTO
			_Output
		FROM "fnc_User_Record_open_all"(
		);
	
		RETURN _Output;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."fnc0_User_Record_count_all"() OWNER TO postgres;

--
-- TOC entry 59 (class 1255 OID 17960)
-- Dependencies: 4 314
-- Name: fnc0_User_Record_count_byGroup(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "fnc0_User_Record_count_byGroup"("IDGroup_search_" bigint) RETURNS bigint
    AS $$
	DECLARE
		_Output int8 = 0;
	BEGIN
		SELECT
			COUNT("IDUser")
		INTO
			_Output
		FROM "fnc_User_Record_open_byGroup"(
			"IDGroup_search_"
		);
	
		RETURN _Output;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."fnc0_User_Record_count_byGroup"("IDGroup_search_" bigint) OWNER TO postgres;

--
-- TOC entry 61 (class 1255 OID 17962)
-- Dependencies: 314 4
-- Name: fnc0_User_Record_hasObject_all(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "fnc0_User_Record_hasObject_all"("IDUser_" bigint) RETURNS boolean
    AS $$
	DECLARE
	BEGIN
		IF EXISTS (
			SELECT
				true -- whatever, just checking existence
			FROM "fnc_User_Record_open_all"(
			)
			WHERE
				("IDUser" = "IDUser_")
		) THEN
			RETURN true;
		END IF;
	
		RETURN false;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."fnc0_User_Record_hasObject_all"("IDUser_" bigint) OWNER TO postgres;

--
-- TOC entry 62 (class 1255 OID 17963)
-- Dependencies: 4 314
-- Name: fnc0_User_Record_hasObject_byGroup(bigint, bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "fnc0_User_Record_hasObject_byGroup"("IDUser_" bigint, "IDGroup_search_" bigint) RETURNS boolean
    AS $$
	DECLARE
	BEGIN
		IF EXISTS (
			SELECT
				true -- whatever, just checking existence
			FROM "fnc_User_Record_open_byGroup"(
				"IDGroup_search_"
			)
			WHERE
				("IDUser" = "IDUser_")
		) THEN
			RETURN true;
		END IF;
	
		RETURN false;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."fnc0_User_Record_hasObject_byGroup"("IDUser_" bigint, "IDGroup_search_" bigint) OWNER TO postgres;

--
-- TOC entry 56 (class 1255 OID 17957)
-- Dependencies: 4 314
-- Name: fnc0_User__ConstraintExist(bigint, character varying, character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "fnc0_User__ConstraintExist"("IDUser_" bigint, "Login_" character varying, "Password_" character varying) RETURNS boolean
    AS $_$
	DECLARE
		-- nothing to declare!
	BEGIN
		IF EXISTS(
			SELECT
				true -- whatever, just checking existence
			FROM "fnc_User_isObject_byLogin"(
				$2
			)
			WHERE NOT (
				("IDUser" = $1)
			)
		) THEN
			RETURN true;
		END IF;

		RETURN false;
	END;
$_$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."fnc0_User__ConstraintExist"("IDUser_" bigint, "Login_" character varying, "Password_" character varying) OWNER TO postgres;

--
-- TOC entry 27 (class 1255 OID 17921)
-- Dependencies: 4 314
-- Name: fnc0_User_isObject(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "fnc0_User_isObject"("IDUser_" bigint) RETURNS boolean
    AS $$
	BEGIN
		RETURN EXISTS(
			SELECT
				true -- whatever, just checking existence
			FROM "User"
			WHERE
				("IDUser" = "IDUser_")
		);
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."fnc0_User_isObject"("IDUser_" bigint) OWNER TO postgres;

--
-- TOC entry 57 (class 1255 OID 17958)
-- Dependencies: 4 314
-- Name: fnc0_User_isObject_byLogin(character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "fnc0_User_isObject_byLogin"("Login_search_" character varying) RETURNS boolean
    AS $$
	BEGIN
		RETURN EXISTS(
			SELECT
				true -- whatever, just checking existence
			FROM "fnc_User_isObject_byLogin"(
				"Login_search_"
			)
		);
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."fnc0_User_isObject_byLogin"("Login_search_" character varying) OWNER TO postgres;

--
-- TOC entry 60 (class 1255 OID 17961)
-- Dependencies: 4 314
-- Name: fnc0_vUserDefaultGroup_Record_count_all(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "fnc0_vUserDefaultGroup_Record_count_all"() RETURNS bigint
    AS $$
	DECLARE
		_Output int8 = 0;
	BEGIN
		SELECT
			COUNT("IDUser")
		INTO
			_Output
		FROM "fnc_vUserDefaultGroup_Record_open_all"(
		);
	
		RETURN _Output;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."fnc0_vUserDefaultGroup_Record_count_all"() OWNER TO postgres;

--
-- TOC entry 63 (class 1255 OID 17964)
-- Dependencies: 314 4
-- Name: fnc0_vUserDefaultGroup_Record_hasObject_all(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "fnc0_vUserDefaultGroup_Record_hasObject_all"("IDUser_" bigint) RETURNS boolean
    AS $$
	DECLARE
	BEGIN
		IF EXISTS (
			SELECT
				true -- whatever, just checking existence
			FROM "fnc_vUserDefaultGroup_Record_open_all"(
			)
			WHERE
				("IDUser" = "IDUser_")
		) THEN
			RETURN true;
		END IF;
	
		RETURN false;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."fnc0_vUserDefaultGroup_Record_hasObject_all"("IDUser_" bigint) OWNER TO postgres;

--
-- TOC entry 29 (class 1255 OID 17923)
-- Dependencies: 4 314
-- Name: fnc0_vUserDefaultGroup_isObject(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "fnc0_vUserDefaultGroup_isObject"("IDUser_" bigint) RETURNS boolean
    AS $$
	BEGIN
		RETURN EXISTS(
			SELECT
				true -- whatever, just checking existence
			FROM "vUserDefaultGroup"
			WHERE
				("IDUser" = "IDUser_")
		);
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."fnc0_vUserDefaultGroup_isObject"("IDUser_" bigint) OWNER TO postgres;

--
-- TOC entry 30 (class 1255 OID 17924)
-- Dependencies: 4 314
-- Name: fnc0_vUserGroup_isObject(bigint, bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "fnc0_vUserGroup_isObject"("IDUser_" bigint, "IDGroup_" bigint) RETURNS boolean
    AS $$
	BEGIN
		RETURN EXISTS(
			SELECT
				true -- whatever, just checking existence
			FROM "vUserGroup"
			WHERE
				("IDUser" = "IDUser_") AND
				("IDGroup" = "IDGroup_")
		);
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."fnc0_vUserGroup_isObject"("IDUser_" bigint, "IDGroup_" bigint) OWNER TO postgres;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 1249 (class 1259 OID 17871)
-- Dependencies: 4
-- Name: User; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE "User" (
    "IDUser" bigserial NOT NULL,
    "Login" character varying(50) NOT NULL,
    "Password" character varying(50) NOT NULL
);


ALTER TABLE public."User" OWNER TO postgres;

--
-- TOC entry 1258 (class 1259 OID 17907)
-- Dependencies: 1331 4
-- Name: v0_User__onlyKeys; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW "v0_User__onlyKeys" AS
    SELECT "User"."IDUser" FROM "User";


ALTER TABLE public."v0_User__onlyKeys" OWNER TO postgres;

--
-- TOC entry 17 (class 1255 OID 17933)
-- Dependencies: 314 4 310
-- Name: fnc_User_Record_open_all(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "fnc_User_Record_open_all"() RETURNS SETOF "v0_User__onlyKeys"
    AS $$
	DECLARE
		_Output "v0_User__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				"IDUser"
			FROM "User"/*
			WHERE*/
		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."fnc_User_Record_open_all"() OWNER TO postgres;

--
-- TOC entry 22 (class 1255 OID 17934)
-- Dependencies: 314 310 4
-- Name: fnc_User_Record_open_byGroup(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "fnc_User_Record_open_byGroup"("IDGroup_search_" bigint) RETURNS SETOF "v0_User__onlyKeys"
    AS $$
	DECLARE
		_Output "v0_User__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				"IDUser"
			FROM "UserGroup"
			WHERE
				("IDGroup" = "IDGroup_search_")
		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."fnc_User_Record_open_byGroup"("IDGroup_search_" bigint) OWNER TO postgres;

--
-- TOC entry 23 (class 1255 OID 17932)
-- Dependencies: 314 4 310
-- Name: fnc_User_isObject_byLogin(character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "fnc_User_isObject_byLogin"("Login_search_" character varying) RETURNS SETOF "v0_User__onlyKeys"
    AS $$
	DECLARE
		_Output "v0_User__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				"IDUser"
			FROM "User"
			WHERE
				--("Login" LIKE '%' || "Login_search_" || '%')
				("Login" = "Login_search_")
		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."fnc_User_isObject_byLogin"("Login_search_" character varying) OWNER TO postgres;

--
-- TOC entry 1251 (class 1259 OID 17880)
-- Dependencies: 4
-- Name: Group; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE "Group" (
    "IDGroup" bigserial NOT NULL,
    "Name" character varying(50) NOT NULL
);


ALTER TABLE public."Group" OWNER TO postgres;

--
-- TOC entry 1252 (class 1259 OID 17887)
-- Dependencies: 4
-- Name: UserGroup; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE "UserGroup" (
    "IDUser" bigint NOT NULL,
    "IDGroup" bigint NOT NULL,
    "Relationdate" timestamp without time zone NOT NULL,
    "Defaultrelation" boolean NOT NULL
);


ALTER TABLE public."UserGroup" OWNER TO postgres;

--
-- TOC entry 1255 (class 1259 OID 17898)
-- Dependencies: 1328 4
-- Name: vUserDefaultGroup; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW "vUserDefaultGroup" AS
    SELECT t2."IDUser", t2."Login", t3."IDGroup", t3."Name", t1."Relationdate" FROM (("UserGroup" t1 JOIN "User" t2 ON ((t2."IDUser" = t1."IDUser"))) JOIN "Group" t3 ON ((t3."IDGroup" = t1."IDGroup"))) WHERE (t1."Defaultrelation" = true);


ALTER TABLE public."vUserDefaultGroup" OWNER TO postgres;

--
-- TOC entry 1260 (class 1259 OID 17913)
-- Dependencies: 1333 4
-- Name: v0_vUserDefaultGroup__onlyKeys; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW "v0_vUserDefaultGroup__onlyKeys" AS
    SELECT "vUserDefaultGroup"."IDUser" FROM "vUserDefaultGroup";


ALTER TABLE public."v0_vUserDefaultGroup__onlyKeys" OWNER TO postgres;

--
-- TOC entry 18 (class 1255 OID 17935)
-- Dependencies: 4 314 312
-- Name: fnc_vUserDefaultGroup_Record_open_all(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "fnc_vUserDefaultGroup_Record_open_all"() RETURNS SETOF "v0_vUserDefaultGroup__onlyKeys"
    AS $$
	DECLARE
		_Output "v0_vUserDefaultGroup__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				"IDUser"
			FROM "vUserDefaultGroup"/*
			WHERE*/
		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."fnc_vUserDefaultGroup_Record_open_all"() OWNER TO postgres;

--
-- TOC entry 34 (class 1255 OID 17927)
-- Dependencies: 314 4
-- Name: sp0_Config_delObject(character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_Config_delObject"("Name_" character varying) RETURNS void
    AS $$
	BEGIN
		DELETE
		FROM "Config"
		WHERE
			("Name" = "Name_");

		RETURN;
	END;
$$
    LANGUAGE plpgsql;


ALTER FUNCTION public."sp0_Config_delObject"("Name_" character varying) OWNER TO postgres;

--
-- TOC entry 1253 (class 1259 OID 17891)
-- Dependencies: 4
-- Name: Config; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE "Config" (
    "Name" character varying(50) NOT NULL,
    "Config" character varying(50) NOT NULL,
    "Type" integer NOT NULL
);


ALTER TABLE public."Config" OWNER TO postgres;

--
-- TOC entry 39 (class 1255 OID 17939)
-- Dependencies: 314 4 305
-- Name: sp0_Config_getObject(character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_Config_getObject"("Name_" character varying) RETURNS "Config"
    AS $$
	DECLARE
		_Output "Config"%ROWTYPE;
		_Exists boolean = false;
	BEGIN

		SELECT
			"Name", 
			"Config", 
			"Type", 
			true
		INTO
			_Output."Name", 
			_Output."Config", 
			_Output."Type", 
			_Exists
		FROM "Config"
		WHERE
			("Name" = "Name_");

		IF NOT (_Exists) THEN
			_Output."Name" := NULL;
			_Output."Config" := NULL;
			_Output."Type" := NULL;
		END IF;

		RETURN _Output;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."sp0_Config_getObject"("Name_" character varying) OWNER TO postgres;

--
-- TOC entry 32 (class 1255 OID 17925)
-- Dependencies: 314 4
-- Name: sp0_Config_setObject(character varying, character varying, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_Config_setObject"("Name_" character varying, "Config_" character varying, "Type_" integer) RETURNS integer
    AS $$
	/*************************************
	 *  returns                          *
	 *    00 0: not exist, no constraint *
	 *    01 1: exists, no constraint    *
	 *    10 2: constraint, not exist    *
	 *    11 3: exists, constraint       *
	 *                                   *
	 *  bit 0: existance                 *
	 *  bit 1: constraint                *
	 *************************************/

	DECLARE
		_Exists bool; 
		_ConstraintExist bool;
		_Output int4;
	BEGIN
		_Exists := EXISTS (
			SELECT true -- whatever, just checking existence
			FROM "Config"
			WHERE
				("Name" = "Name_")
		);
		IF (_Exists) THEN
			_ConstraintExist := 0;
			IF NOT (_ConstraintExist) THEN
				UPDATE "Config"
				SET
					"Config" = "Config_", 
					"Type" = "Type_"
				WHERE
					("Name" = "Name_");
			END IF;
		ELSE
			_ConstraintExist := 0;
			IF NOT (_ConstraintExist) THEN
				INSERT INTO "Config" (
					"Name", 
					"Config", 
					"Type"
				) VALUES (
					"Name_", 
					"Config_", 
					"Type_"
				);
			END IF;
		END IF;

		_Output := 0;
		IF (_Exists) THEN _Output := _Output + 1; END IF;
		IF (_ConstraintExist) THEN _Output := _Output + 2; END IF;
		RETURN _Output AS "Output_";
	END;
$$
    LANGUAGE plpgsql;


ALTER FUNCTION public."sp0_Config_setObject"("Name_" character varying, "Config_" character varying, "Type_" integer) OWNER TO postgres;

--
-- TOC entry 35 (class 1255 OID 17928)
-- Dependencies: 4 314
-- Name: sp0_Group_delObject(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_Group_delObject"("IDGroup_" bigint) RETURNS void
    AS $$
	BEGIN
		DELETE
		FROM "Group"
		WHERE
			("IDGroup" = "IDGroup_");

		RETURN;
	END;
$$
    LANGUAGE plpgsql;


ALTER FUNCTION public."sp0_Group_delObject"("IDGroup_" bigint) OWNER TO postgres;

--
-- TOC entry 40 (class 1255 OID 17940)
-- Dependencies: 4 303 314
-- Name: sp0_Group_getObject(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_Group_getObject"("IDGroup_" bigint) RETURNS "Group"
    AS $$
	DECLARE
		_Output "Group"%ROWTYPE;
		_Exists boolean = false;
	BEGIN

		SELECT
			"IDGroup", 
			"Name", 
			true
		INTO
			_Output."IDGroup", 
			_Output."Name", 
			_Exists
		FROM "Group"
		WHERE
			("IDGroup" = "IDGroup_");

		IF NOT (_Exists) THEN
			_Output."IDGroup" := NULL;
			_Output."Name" := NULL;
		END IF;

		RETURN _Output;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."sp0_Group_getObject"("IDGroup_" bigint) OWNER TO postgres;

--
-- TOC entry 64 (class 1255 OID 17965)
-- Dependencies: 4 314
-- Name: sp0_Group_insObject(character varying, boolean); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_Group_insObject"("Name_" character varying, "SelectIdentity_" boolean) RETURNS bigint
    AS $$
	/**********************************
	 *  returns                       *
	 *   -1: constraint exists        *
	 *    0: no need to get Identity  *
	 *   >0: Identity                 *
	 **********************************/

	DECLARE
		IdentityKey bigint = CAST(0 AS bigint);
	BEGIN
			INSERT INTO "Group" (
				"Name"
			) VALUES (
				"Name_"
			);
			IF ("SelectIdentity_") THEN
				SELECT
					"IDGroup"
				INTO
					IdentityKey
				FROM "Group"
				ORDER BY "IDGroup" DESC LIMIT 1;
			ELSE
				IdentityKey := CAST(0 AS bigint);
			END IF;

		RETURN IdentityKey AS "IDGroup_";
	END;
$$
    LANGUAGE plpgsql;


ALTER FUNCTION public."sp0_Group_insObject"("Name_" character varying, "SelectIdentity_" boolean) OWNER TO postgres;

--
-- TOC entry 66 (class 1255 OID 17967)
-- Dependencies: 314 4
-- Name: sp0_Group_updObject(bigint, character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_Group_updObject"("IDGroup_" bigint, "Name_" character varying) RETURNS boolean
    AS $$
	/***********************************************
	 *  returns                                    *
	 *    true: constraint exists, update NOT made * 
	 *    false: NO constraint, update made        *
	 ***********************************************/

	BEGIN
			UPDATE "Group"
			SET
				"Name" = "Name_"
			WHERE
				("IDGroup" = "IDGroup_")
			;

			RETURN false AS "ConstraintExist_";
	END;
$$
    LANGUAGE plpgsql;


ALTER FUNCTION public."sp0_Group_updObject"("IDGroup_" bigint, "Name_" character varying) OWNER TO postgres;

--
-- TOC entry 36 (class 1255 OID 17929)
-- Dependencies: 314 4
-- Name: sp0_UserGroup_delObject(bigint, bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_UserGroup_delObject"("IDUser_" bigint, "IDGroup_" bigint) RETURNS void
    AS $$
	BEGIN
		DELETE
		FROM "UserGroup"
		WHERE
			("IDUser" = "IDUser_") AND
			("IDGroup" = "IDGroup_");

		RETURN;
	END;
$$
    LANGUAGE plpgsql;


ALTER FUNCTION public."sp0_UserGroup_delObject"("IDUser_" bigint, "IDGroup_" bigint) OWNER TO postgres;

--
-- TOC entry 42 (class 1255 OID 17942)
-- Dependencies: 304 314 4
-- Name: sp0_UserGroup_getObject(bigint, bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_UserGroup_getObject"("IDUser_" bigint, "IDGroup_" bigint) RETURNS "UserGroup"
    AS $$
	DECLARE
		_Output "UserGroup"%ROWTYPE;
		_Exists boolean = false;
	BEGIN

		SELECT
			"IDUser", 
			"IDGroup", 
			"Relationdate", 
			"Defaultrelation", 
			true
		INTO
			_Output."IDUser", 
			_Output."IDGroup", 
			_Output."Relationdate", 
			_Output."Defaultrelation", 
			_Exists
		FROM "UserGroup"
		WHERE
			("IDUser" = "IDUser_") AND
			("IDGroup" = "IDGroup_");

		IF NOT (_Exists) THEN
			_Output."IDUser" := NULL;
			_Output."IDGroup" := NULL;
			_Output."Relationdate" := NULL;
			_Output."Defaultrelation" := NULL;
		END IF;

		RETURN _Output;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."sp0_UserGroup_getObject"("IDUser_" bigint, "IDGroup_" bigint) OWNER TO postgres;

--
-- TOC entry 33 (class 1255 OID 17926)
-- Dependencies: 4 314
-- Name: sp0_UserGroup_setObject(bigint, bigint, timestamp without time zone, boolean); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_UserGroup_setObject"("IDUser_" bigint, "IDGroup_" bigint, "Relationdate_" timestamp without time zone, "Defaultrelation_" boolean) RETURNS integer
    AS $$
	/*************************************
	 *  returns                          *
	 *    00 0: not exist, no constraint *
	 *    01 1: exists, no constraint    *
	 *    10 2: constraint, not exist    *
	 *    11 3: exists, constraint       *
	 *                                   *
	 *  bit 0: existance                 *
	 *  bit 1: constraint                *
	 *************************************/

	DECLARE
		_Exists bool; 
		_ConstraintExist bool;
		_Output int4;
	BEGIN
		_Exists := EXISTS (
			SELECT true -- whatever, just checking existence
			FROM "UserGroup"
			WHERE
				("IDUser" = "IDUser_") AND
				("IDGroup" = "IDGroup_")
		);
		IF (_Exists) THEN
			_ConstraintExist := 0;
			IF NOT (_ConstraintExist) THEN
				UPDATE "UserGroup"
				SET
					"Relationdate" = "Relationdate_", 
					"Defaultrelation" = "Defaultrelation_"
				WHERE
					("IDUser" = "IDUser_") AND
					("IDGroup" = "IDGroup_");
			END IF;
		ELSE
			_ConstraintExist := 0;
			IF NOT (_ConstraintExist) THEN
				INSERT INTO "UserGroup" (
					"IDUser", 
					"IDGroup", 
					"Relationdate", 
					"Defaultrelation"
				) VALUES (
					"IDUser_", 
					"IDGroup_", 
					"Relationdate_", 
					"Defaultrelation_"
				);
			END IF;
		END IF;

		_Output := 0;
		IF (_Exists) THEN _Output := _Output + 1; END IF;
		IF (_ConstraintExist) THEN _Output := _Output + 2; END IF;
		RETURN _Output AS "Output_";
	END;
$$
    LANGUAGE plpgsql;


ALTER FUNCTION public."sp0_UserGroup_setObject"("IDUser_" bigint, "IDGroup_" bigint, "Relationdate_" timestamp without time zone, "Defaultrelation_" boolean) OWNER TO postgres;

--
-- TOC entry 68 (class 1255 OID 17970)
-- Dependencies: 4 314
-- Name: sp0_User_Record_delete_all(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_User_Record_delete_all"() RETURNS void
    AS $$
	DECLARE
		_User "v0_User__onlyKeys";
	BEGIN
		FOR _User IN
			SELECT
				"IDUser"
			FROM "fnc_User_Record_open_all"(
			)
		LOOP
			DELETE FROM "User"
			WHERE
				("IDUser" = _User."IDUser");
		END LOOP;

		/***************************************************************
		 * does not work with PostgreSQL :(
		 *

		DELETE --"User"
		FROM "User" --t1
			INNER JOIN "fnc_User_Record_open_all"(
			) t2 ON
				(t2."IDUser" = --t1.
				"IDUser");

		 *
		 ***************************************************************/

		RETURN;
	END;
$$
    LANGUAGE plpgsql;


ALTER FUNCTION public."sp0_User_Record_delete_all"() OWNER TO postgres;

--
-- TOC entry 69 (class 1255 OID 17971)
-- Dependencies: 4 314
-- Name: sp0_User_Record_delete_byGroup(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_User_Record_delete_byGroup"("IDGroup_search_" bigint) RETURNS void
    AS $$
	DECLARE
		_User "v0_User__onlyKeys";
	BEGIN
		FOR _User IN
			SELECT
				"IDUser"
			FROM "fnc_User_Record_open_byGroup"(
				"IDGroup_search_"
			)
		LOOP
			DELETE FROM "User"
			WHERE
				("IDUser" = _User."IDUser");
		END LOOP;

		/***************************************************************
		 * does not work with PostgreSQL :(
		 *

		DELETE --"User"
		FROM "User" --t1
			INNER JOIN "fnc_User_Record_open_byGroup"(
				"IDGroup_search_"
			) t2 ON
				(t2."IDUser" = --t1.
				"IDUser");

		 *
		 ***************************************************************/

		RETURN;
	END;
$$
    LANGUAGE plpgsql;


ALTER FUNCTION public."sp0_User_Record_delete_byGroup"("IDGroup_search_" bigint) OWNER TO postgres;

--
-- TOC entry 46 (class 1255 OID 17946)
-- Dependencies: 314 4 301
-- Name: sp0_User_Record_open_all_fullmode(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_User_Record_open_all_fullmode"() RETURNS SETOF "User"
    AS $$
	DECLARE
		_Output "User";
	BEGIN
		FOR _Output IN
			SELECT
				t1."IDUser", 
				t1."Login", 
				t1."Password"
			FROM "User" t1
			INNER JOIN "sp_User_Record_open_all"(
			) t2 ON (
				(t2."IDUser" = t1."IDUser")
			)

			-- change where condition in: "fnc_User_Record_open_all"
			-- NOT HERE!

			-- change order by in: "sp_User_Record_open_all"
			-- NOT HERE!

		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."sp0_User_Record_open_all_fullmode"() OWNER TO postgres;

--
-- TOC entry 49 (class 1255 OID 17949)
-- Dependencies: 314 310 4
-- Name: sp0_User_Record_open_all_page(integer, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_User_Record_open_all_page"(page_ integer, "page_numRecords_" integer) RETURNS SETOF "v0_User__onlyKeys"
    AS $$
	DECLARE
		_Output "v0_User__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				t1."IDUser"
			FROM "User" t1
			INNER JOIN "sp_User_Record_open_all"(
			) t2 ON (
				(t2."IDUser" = t1."IDUser")
			)

			-- change where condition in: "fnc_User_Record_open_all"
			-- NOT HERE!

			-- change order by in: "sp_User_Record_open_all"
			-- NOT HERE!

			LIMIT "page_numRecords_" OFFSET "page_numRecords_" * ("page_" - 1)
		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."sp0_User_Record_open_all_page"(page_ integer, "page_numRecords_" integer) OWNER TO postgres;

--
-- TOC entry 52 (class 1255 OID 17952)
-- Dependencies: 314 4 301
-- Name: sp0_User_Record_open_all_page_fullmode(integer, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_User_Record_open_all_page_fullmode"(page_ integer, "page_numRecords_" integer) RETURNS SETOF "User"
    AS $$
	DECLARE
		_Output "User";
	BEGIN
		FOR _Output IN
			SELECT
				t1."IDUser", 
				t1."Login", 
				t1."Password"
			FROM "User" t1
			INNER JOIN "sp_User_Record_open_all"(
			) t2 ON (
				(t2."IDUser" = t1."IDUser")
			)

			-- change where condition in: "fnc_User_Record_open_all"
			-- NOT HERE!

			-- change order by in: "sp_User_Record_open_all"
			-- NOT HERE!

			LIMIT "page_numRecords_" OFFSET "page_numRecords_" * ("page_" - 1)
		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."sp0_User_Record_open_all_page_fullmode"(page_ integer, "page_numRecords_" integer) OWNER TO postgres;

--
-- TOC entry 47 (class 1255 OID 17947)
-- Dependencies: 314 301 4
-- Name: sp0_User_Record_open_byGroup_fullmode(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_User_Record_open_byGroup_fullmode"("IDGroup_search_" bigint) RETURNS SETOF "User"
    AS $$
	DECLARE
		_Output "User";
	BEGIN
		FOR _Output IN
			SELECT
				t1."IDUser", 
				t1."Login", 
				t1."Password"
			FROM "User" t1
			INNER JOIN "sp_User_Record_open_byGroup"(
				"IDGroup_search_"
			) t2 ON (
				(t2."IDUser" = t1."IDUser")
			)

			-- change where condition in: "fnc_User_Record_open_byGroup"
			-- NOT HERE!

			-- change order by in: "sp_User_Record_open_byGroup"
			-- NOT HERE!

		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."sp0_User_Record_open_byGroup_fullmode"("IDGroup_search_" bigint) OWNER TO postgres;

--
-- TOC entry 50 (class 1255 OID 17950)
-- Dependencies: 310 314 4
-- Name: sp0_User_Record_open_byGroup_page(bigint, integer, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_User_Record_open_byGroup_page"("IDGroup_search_" bigint, page_ integer, "page_numRecords_" integer) RETURNS SETOF "v0_User__onlyKeys"
    AS $$
	DECLARE
		_Output "v0_User__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				t1."IDUser"
			FROM "User" t1
			INNER JOIN "sp_User_Record_open_byGroup"(
				"IDGroup_search_"
			) t2 ON (
				(t2."IDUser" = t1."IDUser")
			)

			-- change where condition in: "fnc_User_Record_open_byGroup"
			-- NOT HERE!

			-- change order by in: "sp_User_Record_open_byGroup"
			-- NOT HERE!

			LIMIT "page_numRecords_" OFFSET "page_numRecords_" * ("page_" - 1)
		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."sp0_User_Record_open_byGroup_page"("IDGroup_search_" bigint, page_ integer, "page_numRecords_" integer) OWNER TO postgres;

--
-- TOC entry 53 (class 1255 OID 17953)
-- Dependencies: 314 4 301
-- Name: sp0_User_Record_open_byGroup_page_fullmode(bigint, integer, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_User_Record_open_byGroup_page_fullmode"("IDGroup_search_" bigint, page_ integer, "page_numRecords_" integer) RETURNS SETOF "User"
    AS $$
	DECLARE
		_Output "User";
	BEGIN
		FOR _Output IN
			SELECT
				t1."IDUser", 
				t1."Login", 
				t1."Password"
			FROM "User" t1
			INNER JOIN "sp_User_Record_open_byGroup"(
				"IDGroup_search_"
			) t2 ON (
				(t2."IDUser" = t1."IDUser")
			)

			-- change where condition in: "fnc_User_Record_open_byGroup"
			-- NOT HERE!

			-- change order by in: "sp_User_Record_open_byGroup"
			-- NOT HERE!

			LIMIT "page_numRecords_" OFFSET "page_numRecords_" * ("page_" - 1)
		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."sp0_User_Record_open_byGroup_page_fullmode"("IDGroup_search_" bigint, page_ integer, "page_numRecords_" integer) OWNER TO postgres;

--
-- TOC entry 25 (class 1255 OID 17955)
-- Dependencies: 4 314
-- Name: sp0_User_Record_update_SomeUpdateTest_byGroup(bigint, character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_User_Record_update_SomeUpdateTest_byGroup"("IDGroup_search_" bigint, "Password_update_" character varying) RETURNS void
    AS $$
	DECLARE
	BEGIN
		UPDATE "User"
		SET
			"Password" = "Password_update_"
		FROM "fnc_User_Record_open_byGroup"(
			"IDGroup_search_"
		) t1
		WHERE
			(t1."IDUser" = "User"."IDUser");

		RETURN;
	END;
$$
    LANGUAGE plpgsql;


ALTER FUNCTION public."sp0_User_Record_update_SomeUpdateTest_byGroup"("IDGroup_search_" bigint, "Password_update_" character varying) OWNER TO postgres;

--
-- TOC entry 31 (class 1255 OID 17969)
-- Dependencies: 314 4
-- Name: sp0_User_delObject_byLogin(character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_User_delObject_byLogin"("Login_search_" character varying) RETURNS boolean
    AS $$
	DECLARE
		_Exists bool = false;
		_User "v0_User__onlyKeys";
	BEGIN
		SELECT
			"IDUser", 
			true
		INTO
			_User."IDUser", 
			_Exists
		FROM "fnc_User_isObject_byLogin"(
			"Login_search_"
		);

		IF (_Exists) THEN
			DELETE
			FROM "User"
			WHERE
				("IDUser" = _User."IDUser")
			;

			RETURN true AS "Exists_";
		END IF;

		RETURN false AS "Exists_";
	END;
$$
    LANGUAGE plpgsql;


ALTER FUNCTION public."sp0_User_delObject_byLogin"("Login_search_" character varying) OWNER TO postgres;

--
-- TOC entry 41 (class 1255 OID 17941)
-- Dependencies: 4 314 301
-- Name: sp0_User_getObject(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_User_getObject"("IDUser_" bigint) RETURNS "User"
    AS $$
	DECLARE
		_Output "User"%ROWTYPE;
		_Exists boolean = false;
	BEGIN

		SELECT
			"IDUser", 
			"Login", 
			"Password", 
			true
		INTO
			_Output."IDUser", 
			_Output."Login", 
			_Output."Password", 
			_Exists
		FROM "User"
		WHERE
			("IDUser" = "IDUser_");

		IF NOT (_Exists) THEN
			_Output."IDUser" := NULL;
			_Output."Login" := NULL;
			_Output."Password" := NULL;
		END IF;

		RETURN _Output;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."sp0_User_getObject"("IDUser_" bigint) OWNER TO postgres;

--
-- TOC entry 45 (class 1255 OID 17945)
-- Dependencies: 4 314 301
-- Name: sp0_User_getObject_byLogin(character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_User_getObject_byLogin"("Login_search_" character varying) RETURNS "User"
    AS $$
	DECLARE
		_Output "User"%ROWTYPE;
		_Exists boolean = false;
	BEGIN

		SELECT
			t1."IDUser", 
			t1."Login", 
			t1."Password", 
			true
		INTO
			_Output."IDUser", 
			_Output."Login", 
			_Output."Password", 
			_Exists
		FROM "User" t1
		INNER JOIN "fnc_User_isObject_byLogin"(
			"Login_search_"
		) t2 ON (
			(t2."IDUser" = t1."IDUser")
		);
	
		IF NOT (_Exists) THEN
			_Output."IDUser" := NULL;
			_Output."Login" := NULL;
			_Output."Password" := NULL;
		END IF;

		RETURN _Output;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."sp0_User_getObject_byLogin"("Login_search_" character varying) OWNER TO postgres;

--
-- TOC entry 65 (class 1255 OID 17966)
-- Dependencies: 314 4
-- Name: sp0_User_insObject(character varying, character varying, boolean); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_User_insObject"("Login_" character varying, "Password_" character varying, "SelectIdentity_" boolean) RETURNS bigint
    AS $$
	/**********************************
	 *  returns                       *
	 *   -1: constraint exists        *
	 *    0: no need to get Identity  *
	 *   >0: Identity                 *
	 **********************************/

	DECLARE
		IdentityKey bigint = CAST(0 AS bigint);
	BEGIN
		IF ("fnc0_User__ConstraintExist"(
			CAST(0 AS bigint), 
			"Login_", 
			"Password_"
		)) THEN
			IdentityKey := CAST(-1 AS bigint);
		ELSE
			INSERT INTO "User" (
				"Login", 
				"Password"
			) VALUES (
				"Login_", 
				"Password_"
			);
			IF ("SelectIdentity_") THEN
				SELECT
					"IDUser"
				INTO
					IdentityKey
				FROM "User"
				ORDER BY "IDUser" DESC LIMIT 1;
			ELSE
				IdentityKey := CAST(0 AS bigint);
			END IF;
		END IF;

		RETURN IdentityKey AS "IDUser_";
	END;
$$
    LANGUAGE plpgsql;


ALTER FUNCTION public."sp0_User_insObject"("Login_" character varying, "Password_" character varying, "SelectIdentity_" boolean) OWNER TO postgres;

--
-- TOC entry 67 (class 1255 OID 17968)
-- Dependencies: 4 314
-- Name: sp0_User_updObject(bigint, character varying, character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_User_updObject"("IDUser_" bigint, "Login_" character varying, "Password_" character varying) RETURNS boolean
    AS $$
	/***********************************************
	 *  returns                                    *
	 *    true: constraint exists, update NOT made * 
	 *    false: NO constraint, update made        *
	 ***********************************************/

	BEGIN
		IF ("fnc0_User__ConstraintExist"(
			"IDUser_", 
			"Login_", 
			"Password_"
		)) THEN
			RETURN true AS "ConstraintExist";
		ELSE
			UPDATE "User"
			SET
				"Login" = "Login_", 
				"Password" = "Password_"
			WHERE
				("IDUser" = "IDUser_")
			;

			RETURN false AS "ConstraintExist_";
		END IF;
	END;
$$
    LANGUAGE plpgsql;


ALTER FUNCTION public."sp0_User_updObject"("IDUser_" bigint, "Login_" character varying, "Password_" character varying) OWNER TO postgres;

--
-- TOC entry 55 (class 1255 OID 17956)
-- Dependencies: 4
-- Name: sp0__APAGAR(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0__APAGAR"() RETURNS boolean
    AS $$
	SELECT false;
$$
    LANGUAGE sql;


ALTER FUNCTION public."sp0__APAGAR"() OWNER TO postgres;

--
-- TOC entry 48 (class 1255 OID 17948)
-- Dependencies: 4 307 314
-- Name: sp0_vUserDefaultGroup_Record_open_all_fullmode(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_vUserDefaultGroup_Record_open_all_fullmode"() RETURNS SETOF "vUserDefaultGroup"
    AS $$
	DECLARE
		_Output "vUserDefaultGroup";
	BEGIN
		FOR _Output IN
			SELECT
				t1."IDUser", 
				t1."Login", 
				t1."IDGroup", 
				t1."Name", 
				t1."Relationdate"
			FROM "vUserDefaultGroup" t1
			INNER JOIN "sp_vUserDefaultGroup_Record_open_all"(
			) t2 ON (
				(t2."IDUser" = t1."IDUser")
			)

			-- change where condition in: "fnc_vUserDefaultGroup_Record_open_all"
			-- NOT HERE!

			-- change order by in: "sp_vUserDefaultGroup_Record_open_all"
			-- NOT HERE!

		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."sp0_vUserDefaultGroup_Record_open_all_fullmode"() OWNER TO postgres;

--
-- TOC entry 51 (class 1255 OID 17951)
-- Dependencies: 4 314 312
-- Name: sp0_vUserDefaultGroup_Record_open_all_page(integer, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_vUserDefaultGroup_Record_open_all_page"(page_ integer, "page_numRecords_" integer) RETURNS SETOF "v0_vUserDefaultGroup__onlyKeys"
    AS $$
	DECLARE
		_Output "v0_vUserDefaultGroup__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				t1."IDUser"
			FROM "vUserDefaultGroup" t1
			INNER JOIN "sp_vUserDefaultGroup_Record_open_all"(
			) t2 ON (
				(t2."IDUser" = t1."IDUser")
			)

			-- change where condition in: "fnc_vUserDefaultGroup_Record_open_all"
			-- NOT HERE!

			-- change order by in: "sp_vUserDefaultGroup_Record_open_all"
			-- NOT HERE!

			LIMIT "page_numRecords_" OFFSET "page_numRecords_" * ("page_" - 1)
		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."sp0_vUserDefaultGroup_Record_open_all_page"(page_ integer, "page_numRecords_" integer) OWNER TO postgres;

--
-- TOC entry 54 (class 1255 OID 17954)
-- Dependencies: 314 4 307
-- Name: sp0_vUserDefaultGroup_Record_open_all_page_fullmode(integer, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_vUserDefaultGroup_Record_open_all_page_fullmode"(page_ integer, "page_numRecords_" integer) RETURNS SETOF "vUserDefaultGroup"
    AS $$
	DECLARE
		_Output "vUserDefaultGroup";
	BEGIN
		FOR _Output IN
			SELECT
				t1."IDUser", 
				t1."Login", 
				t1."IDGroup", 
				t1."Name", 
				t1."Relationdate"
			FROM "vUserDefaultGroup" t1
			INNER JOIN "sp_vUserDefaultGroup_Record_open_all"(
			) t2 ON (
				(t2."IDUser" = t1."IDUser")
			)

			-- change where condition in: "fnc_vUserDefaultGroup_Record_open_all"
			-- NOT HERE!

			-- change order by in: "sp_vUserDefaultGroup_Record_open_all"
			-- NOT HERE!

			LIMIT "page_numRecords_" OFFSET "page_numRecords_" * ("page_" - 1)
		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."sp0_vUserDefaultGroup_Record_open_all_page_fullmode"(page_ integer, "page_numRecords_" integer) OWNER TO postgres;

--
-- TOC entry 37 (class 1255 OID 17930)
-- Dependencies: 4 314
-- Name: sp0_vUserDefaultGroup_delObject(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_vUserDefaultGroup_delObject"("IDUser_" bigint) RETURNS void
    AS $$
	BEGIN
		DELETE
		FROM "vUserDefaultGroup"
		WHERE
			("IDUser" = "IDUser_");

		RETURN;
	END;
$$
    LANGUAGE plpgsql;


ALTER FUNCTION public."sp0_vUserDefaultGroup_delObject"("IDUser_" bigint) OWNER TO postgres;

--
-- TOC entry 43 (class 1255 OID 17943)
-- Dependencies: 314 307 4
-- Name: sp0_vUserDefaultGroup_getObject(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_vUserDefaultGroup_getObject"("IDUser_" bigint) RETURNS "vUserDefaultGroup"
    AS $$
	DECLARE
		_Output "vUserDefaultGroup"%ROWTYPE;
		_Exists boolean = false;
	BEGIN

		SELECT
			"IDUser", 
			"Login", 
			"IDGroup", 
			"Name", 
			"Relationdate", 
			true
		INTO
			_Output."IDUser", 
			_Output."Login", 
			_Output."IDGroup", 
			_Output."Name", 
			_Output."Relationdate", 
			_Exists
		FROM "vUserDefaultGroup"
		WHERE
			("IDUser" = "IDUser_");

		IF NOT (_Exists) THEN
			_Output."IDUser" := NULL;
			_Output."Login" := NULL;
			_Output."IDGroup" := NULL;
			_Output."Name" := NULL;
			_Output."Relationdate" := NULL;
		END IF;

		RETURN _Output;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."sp0_vUserDefaultGroup_getObject"("IDUser_" bigint) OWNER TO postgres;

--
-- TOC entry 38 (class 1255 OID 17931)
-- Dependencies: 314 4
-- Name: sp0_vUserGroup_delObject(bigint, bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_vUserGroup_delObject"("IDUser_" bigint, "IDGroup_" bigint) RETURNS void
    AS $$
	BEGIN
		DELETE
		FROM "vUserGroup"
		WHERE
			("IDUser" = "IDUser_") AND
			("IDGroup" = "IDGroup_");

		RETURN;
	END;
$$
    LANGUAGE plpgsql;


ALTER FUNCTION public."sp0_vUserGroup_delObject"("IDUser_" bigint, "IDGroup_" bigint) OWNER TO postgres;

--
-- TOC entry 1254 (class 1259 OID 17895)
-- Dependencies: 1327 4
-- Name: vUserGroup; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW "vUserGroup" AS
    SELECT t2."IDUser", t2."Login", t3."IDGroup", t3."Name", t1."Relationdate" FROM (("UserGroup" t1 JOIN "User" t2 ON ((t2."IDUser" = t1."IDUser"))) JOIN "Group" t3 ON ((t3."IDGroup" = t1."IDGroup")));


ALTER TABLE public."vUserGroup" OWNER TO postgres;

--
-- TOC entry 44 (class 1255 OID 17944)
-- Dependencies: 314 306 4
-- Name: sp0_vUserGroup_getObject(bigint, bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp0_vUserGroup_getObject"("IDUser_" bigint, "IDGroup_" bigint) RETURNS "vUserGroup"
    AS $$
	DECLARE
		_Output "vUserGroup"%ROWTYPE;
		_Exists boolean = false;
	BEGIN

		SELECT
			"IDUser", 
			"Login", 
			"IDGroup", 
			"Name", 
			"Relationdate", 
			true
		INTO
			_Output."IDUser", 
			_Output."Login", 
			_Output."IDGroup", 
			_Output."Name", 
			_Output."Relationdate", 
			_Exists
		FROM "vUserGroup"
		WHERE
			("IDUser" = "IDUser_") AND
			("IDGroup" = "IDGroup_");

		IF NOT (_Exists) THEN
			_Output."IDUser" := NULL;
			_Output."Login" := NULL;
			_Output."IDGroup" := NULL;
			_Output."Name" := NULL;
			_Output."Relationdate" := NULL;
		END IF;

		RETURN _Output;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."sp0_vUserGroup_getObject"("IDUser_" bigint, "IDGroup_" bigint) OWNER TO postgres;

--
-- TOC entry 19 (class 1255 OID 17936)
-- Dependencies: 4 314 310
-- Name: sp_User_Record_open_all(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp_User_Record_open_all"() RETURNS SETOF "v0_User__onlyKeys"
    AS $$
	DECLARE
		_Output "v0_User__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				t1."IDUser"
			FROM "User" t1
			INNER JOIN "fnc_User_Record_open_all"(
			) t2 ON (
				(t2."IDUser" = t1."IDUser")
			)

			-- change where condition in: "fnc_User_Record_open_all"
			-- NOT HERE!

			-- change order by HERE:
			-- ORDER BY t1."IDUser" ASC

		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."sp_User_Record_open_all"() OWNER TO postgres;

--
-- TOC entry 20 (class 1255 OID 17937)
-- Dependencies: 314 4 310
-- Name: sp_User_Record_open_byGroup(bigint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp_User_Record_open_byGroup"("IDGroup_search_" bigint) RETURNS SETOF "v0_User__onlyKeys"
    AS $$
	DECLARE
		_Output "v0_User__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				t1."IDUser"
			FROM "User" t1
			INNER JOIN "fnc_User_Record_open_byGroup"(
				"IDGroup_search_"
			) t2 ON (
				(t2."IDUser" = t1."IDUser")
			)

			-- change where condition in: "fnc_User_Record_open_byGroup"
			-- NOT HERE!

			-- change order by HERE:
			-- ORDER BY t1."IDUser" ASC

		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."sp_User_Record_open_byGroup"("IDGroup_search_" bigint) OWNER TO postgres;

--
-- TOC entry 21 (class 1255 OID 17938)
-- Dependencies: 4 314 312
-- Name: sp_vUserDefaultGroup_Record_open_all(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION "sp_vUserDefaultGroup_Record_open_all"() RETURNS SETOF "v0_vUserDefaultGroup__onlyKeys"
    AS $$
	DECLARE
		_Output "v0_vUserDefaultGroup__onlyKeys";
	BEGIN
		FOR _Output IN
			SELECT
				t1."IDUser"
			FROM "vUserDefaultGroup" t1
			INNER JOIN "fnc_vUserDefaultGroup_Record_open_all"(
			) t2 ON (
				(t2."IDUser" = t1."IDUser")
			)

			-- change where condition in: "fnc_vUserDefaultGroup_Record_open_all"
			-- NOT HERE!

			-- change order by HERE:
			-- ORDER BY t1."IDUser" ASC

		LOOP
			RETURN NEXT _Output;
		END LOOP;

		RETURN;
	END;
$$
    LANGUAGE plpgsql STABLE;


ALTER FUNCTION public."sp_vUserDefaultGroup_Record_open_all"() OWNER TO postgres;

--
-- TOC entry 1613 (class 0 OID 0)
-- Dependencies: 1250
-- Name: Group_IDGroup_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval(pg_catalog.pg_get_serial_sequence('"Group"', 'IDGroup'), 3, true);


--
-- TOC entry 1614 (class 0 OID 0)
-- Dependencies: 1248
-- Name: User_IDUser_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval(pg_catalog.pg_get_serial_sequence('"User"', 'IDUser'), 1, true);


--
-- TOC entry 1256 (class 1259 OID 17901)
-- Dependencies: 1329 4
-- Name: v0_Config__onlyKeys; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW "v0_Config__onlyKeys" AS
    SELECT "Config"."Name" FROM "Config";


ALTER TABLE public."v0_Config__onlyKeys" OWNER TO postgres;

--
-- TOC entry 1257 (class 1259 OID 17904)
-- Dependencies: 1330 4
-- Name: v0_Group__onlyKeys; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW "v0_Group__onlyKeys" AS
    SELECT "Group"."IDGroup" FROM "Group";


ALTER TABLE public."v0_Group__onlyKeys" OWNER TO postgres;

--
-- TOC entry 1259 (class 1259 OID 17910)
-- Dependencies: 1332 4
-- Name: v0_UserGroup__onlyKeys; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW "v0_UserGroup__onlyKeys" AS
    SELECT "UserGroup"."IDUser", "UserGroup"."IDGroup" FROM "UserGroup";


ALTER TABLE public."v0_UserGroup__onlyKeys" OWNER TO postgres;

--
-- TOC entry 1261 (class 1259 OID 17916)
-- Dependencies: 1334 4
-- Name: v0_vUserGroup__onlyKeys; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW "v0_vUserGroup__onlyKeys" AS
    SELECT "vUserGroup"."IDUser", "vUserGroup"."IDGroup" FROM "vUserGroup";


ALTER TABLE public."v0_vUserGroup__onlyKeys" OWNER TO postgres;

--
-- TOC entry 1608 (class 0 OID 17891)
-- Dependencies: 1253
-- Data for Name: Config; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "Config" ("Name", "Config", "Type") FROM stdin;
SomeMultiLineStringConfig	line 1\nline 2	3
SomeBoolConfig	False	1
SomeIntConfig	1245	4
SomeStringConfig	whatever	2
\.


--
-- TOC entry 1606 (class 0 OID 17880)
-- Dependencies: 1251
-- Data for Name: Group; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "Group" ("IDGroup", "Name") FROM stdin;
2	SomeOtherGroup
1	SomeGroup
3	YAG
\.


--
-- TOC entry 1605 (class 0 OID 17871)
-- Dependencies: 1249
-- Data for Name: User; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "User" ("IDUser", "Login", "Password") FROM stdin;
1	fmonteiro	passpub
\.


--
-- TOC entry 1607 (class 0 OID 17887)
-- Dependencies: 1252
-- Data for Name: UserGroup; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "UserGroup" ("IDUser", "IDGroup", "Relationdate", "Defaultrelation") FROM stdin;
1	1	2006-04-14 00:00:00	t
\.


--
-- TOC entry 1604 (class 2606 OID 17894)
-- Dependencies: 1253 1253
-- Name: Config_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "Config"
    ADD CONSTRAINT "Config_pkey" PRIMARY KEY ("Name");


--
-- TOC entry 1598 (class 2606 OID 17886)
-- Dependencies: 1251 1251
-- Name: Group_Name_key; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "Group"
    ADD CONSTRAINT "Group_Name_key" UNIQUE ("Name");


--
-- TOC entry 1600 (class 2606 OID 17884)
-- Dependencies: 1251 1251
-- Name: Group_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "Group"
    ADD CONSTRAINT "Group_pkey" PRIMARY KEY ("IDGroup");


--
-- TOC entry 1602 (class 2606 OID 17890)
-- Dependencies: 1252 1252 1252
-- Name: UserGroup_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "UserGroup"
    ADD CONSTRAINT "UserGroup_pkey" PRIMARY KEY ("IDUser", "IDGroup");


--
-- TOC entry 1594 (class 2606 OID 17877)
-- Dependencies: 1249 1249
-- Name: User_Login_key; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "User"
    ADD CONSTRAINT "User_Login_key" UNIQUE ("Login");


--
-- TOC entry 1596 (class 2606 OID 17875)
-- Dependencies: 1249 1249
-- Name: User_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY "User"
    ADD CONSTRAINT "User_pkey" PRIMARY KEY ("IDUser");


--
-- TOC entry 1612 (class 0 OID 0)
-- Dependencies: 4
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


-- Completed on 2006-04-14 21:01:04 GMT Standard Time

--
-- PostgreSQL database dump complete
--

