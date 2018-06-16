-- Function: public.proc_checador(integer, integer, date, timestamp without time zone, timestamp without time zone, integer, integer)

-- DROP FUNCTION public.proc_checador(integer, integer, date, timestamp without time zone, timestamp without time zone, integer, integer);

CREATE OR REPLACE FUNCTION public.proc_checador(
    IN p_id_registro integer,
    IN p_id_ninio integer,
    IN p_dfecha date,
    IN p_dhoraentrada timestamp without time zone,
    IN p_dhorasalida timestamp without time zone,
    IN p_id_personaentrega integer,
    IN p_id_personarecibe integer,
    OUT v_message character varying,
    OUT v_end_code character varying,
    OUT v_users_id bigint)
  RETURNS record AS
$BODY$
    
    DECLARE
      
    BEGIN
     -- GUARDO LOS DATOS DEL USUARIO     
     insert into reg_checador (id_registro,id_ninio,dfecha,dhoraentrada,dhorasalida,id_personaentrega,id_personarecibe) values ( p_id_registro,p_id_ninio,p_dfecha,p_dhoraentrada,p_dhorasalida,p_id_personaentrega,p_id_personarecibe);
 
     v_message := 'Usuario dado de alta con exito, debe verificar su dirección de correo electrónico';
 
     
       
    
     RETURN;
     
    END;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION public.proc_checador(integer, integer, date, timestamp without time zone, timestamp without time zone, integer, integer)
  OWNER TO postgres;
