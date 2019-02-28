
select * from Usuarios

select * from Estudios

select * from Jogos

select Jogos.Nome as Jogos,Estudios.Nome as Estúdios
from Estudios inner join Jogos
on Estudios.ID = Jogos.ID_Estudio


select Jogos.Nome as Jogos,Estudios.Nome as Estúdios
from Estudios left join Jogos
on Estudios.ID = Jogos.ID_Estudio

select USuarios.EMail as Email,Usuarios.Senha as Senha
from Usuarios
where Email = @Email and Senha = @Senha

select * from Jogos 
where Jogos.ID = @ID

select * from Estudios 
where Estudios.ID = @ID