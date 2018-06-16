-- Function: public.proc_ninios(integer, character varying, character varying, character varying, bytea, character varying, bit, timestamp without time zone, integer)

-- DROP FUNCTION public.proc_ninios(integer, character varying, character varying, character varying, bytea, character varying, bit, timestamp without time zone, integer);

CREATE OR REPLACE FUNCTION public.proc_ninios(
    IN p_id_ninio integer,
    IN p_cnombres character varying,
    IN p_capellidopat character varying,
    IN p_capellidomat character varying,
    IN p_huella bytea,
    IN p_cobservaciones character varying,
    IN p_bactivo bit,
    IN p_dfechaultimaactualizacion timestamp without time zone,
    IN p_id_persona integer,
    OUT v_message character varying,
    OUT v_end_code character varying,
    OUT v_users_id bigint)
  RETURNS record AS
$BODY$
    
    DECLARE
      
    BEGIN
     -- GUARDO LOS DATOS DEL USUARIO     
     insert into reg_ninios (id_ninio, cnombres, capellidopat, capellidomat, huella, cobservaciones, 
       bactivo, dfechaultimaactualizacion, id_persona) values ( p_id_ninio, p_cnombres, p_capellidopat, p_capellidomat, p_huella, p_cobservaciones, 
       p_bactivo, p_dfechaultimaactualizacion, p_id_persona);
 
     v_message := 'niño dado de alta con exito';
 
     
       
    
     RETURN;
     
    END;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION public.proc_ninios(integer, character varying, character varying, character varying, bytea, character varying, bit, timestamp without time zone, integer)
  OWNER TO postgres;
