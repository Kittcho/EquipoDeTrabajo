-- Function: public.proc_fotos(integer, bytea)

-- DROP FUNCTION public.proc_fotos(integer, bytea);

CREATE OR REPLACE FUNCTION public.proc_fotos(
    IN p_id_foto integer,
    IN p_imagen bytea,
    OUT v_message character varying,
    OUT v_end_code character varying,
    OUT v_users_id bigint)
  RETURNS record AS
$BODY$
    
    DECLARE
      
    BEGIN
     -- GUARDO LOS DATOS DEL USUARIO     
     insert into reg_fotos ( id_foto, imagen) values (p_id_foto, p_imagen);
 
     v_message := 'foto dado de alta con exito';
 
     
       
    
     RETURN;
     
    END;
$BODY$
  LANGUAGE plpgsql VOLATILE
  COST 100;
ALTER FUNCTION public.proc_fotos(integer, bytea)
  OWNER TO postgres;
