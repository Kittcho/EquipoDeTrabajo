-- Function: public.proc_tipopersonas(integer, character varying)

-- DROP FUNCTION public.proc_tipopersonas(integer, character varying);

CREATE OR REPLACE FUNCTION public.proc_tipopersonas(
    IN p_id_tipo integer,
    IN p_descripciontipo character varying,
    OUT v_message character varying,
    OUT v_end_code character varying,
    OUT v_users_id bigint)
  RETURNS record AS
$BODY$
    
    DECLARE
      
    BEGIN
     -- GUARDO LOS DATOS DEL USUARIO     
     insert into cat_tipospersonas ( id_tipo, descripciontipo) values (  p_id_tipo, p_descripciontipo);
 
     v_message := 'Padre dado de alta con exito';
 
     
       
    
     RETURN;
     
    END;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION public.proc_tipopersonas(integer, character varying)
  OWNER TO postgres;
