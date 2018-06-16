-- Function: public.proc_personas(integer, character varying, character varying, character varying, integer, character varying, character varying, character varying, character varying, integer, character varying, bytea, bit, timestamp without time zone)

-- DROP FUNCTION public.proc_personas(integer, character varying, character varying, character varying, integer, character varying, character varying, character varying, character varying, integer, character varying, bytea, bit, timestamp without time zone);

CREATE OR REPLACE FUNCTION public.proc_personas(
    IN p_id_persona integer,
    IN p_cnombres character varying,
    IN p_capellidopat character varying,
    IN p_capellidomat character varying,
    IN p_id_foto integer,
    IN p_ctel_cel character varying,
    IN p_ccalle character varying,
    IN p_cnum_casa character varying,
    IN p_ccolonia character varying,
    IN p_ncodigopostal integer,
    IN p_cciudad character varying,
    IN p_huella bytea,
    IN p_bactivo bit,
    IN p_dfechaultimaactualizacion timestamp without time zone,
    OUT v_message character varying,
    OUT v_end_code character varying,
    OUT v_users_id bigint)
  RETURNS record AS
$BODY$
    
    DECLARE
      
    BEGIN
     -- GUARDO LOS DATOS DEL USUARIO     
     insert into reg_personas ( id_persona, cnombres, capellidopat, capellidomat, id_foto, ctel_cel, 
       ccalle, cnum_casa, ccolonia, ncodigopostal, cciudad, huella, 
       bactivo, dfechaultimaactualizacion) values ( p_id_persona, p_cnombres, p_capellidopat, p_capellidomat, p_id_foto, p_ctel_cel, 
       p_ccalle, p_cnum_casa, p_ccolonia, p_ncodigopostal, p_cciudad, p_huella, 
       p_bactivo, p_dfechaultimaactualizacion);
 
     v_message := 'Padre dado de alta con exito';
 
     
       
    
     RETURN;
     
    END;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION public.proc_personas(integer, character varying, character varying, character varying, integer, character varying, character varying, character varying, character varying, integer, character varying, bytea, bit, timestamp without time zone)
  OWNER TO postgres;
