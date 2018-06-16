-- Function: public.proc_checadorempl(integer, integer, date, timestamp without time zone, timestamp without time zone)

-- DROP FUNCTION public.proc_checadorempl(integer, integer, date, timestamp without time zone, timestamp without time zone);

CREATE OR REPLACE FUNCTION public.proc_checadorempl(
    IN p_id_registro integer,
    IN p_id_persona integer,
    IN p_dfecha date,
    IN p_dhoraentrada timestamp without time zone,
    IN p_dhorasalida timestamp without time zone,
    OUT v_message character varying,
    OUT v_end_code character varying,
    OUT v_users_id bigint)
  RETURNS record AS
$BODY$
 
    DECLARE
      
    BEGIN
     -- GUARDO LOS DATOS DEL USUARIO     
     insert into reg_checadorEmpleados (id_registro, id_persona ,dfecha,dhoraentrada,dhorasalida) values ( p_id_registro, p_id_persona ,p_dfecha,p_dhoraentrada,p_dhorasalida);
 
     v_message := 'Usuario dado de alta con exito, debe verificar su dirección de correo electrónico';
 
     
       
    
     RETURN;
     
    END;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION public.proc_checadorempl(integer, integer, date, timestamp without time zone, timestamp without time zone)
  OWNER TO postgres;
