
create table SMSSend(
	id number primary key,
	phonenumber varchar2(20),
	message varchar2(1000),
	state number default 0,
	lastdatetime date   default sysdate,
	isRead number   default 0,
	comm number default 1
)


create sequence SMSSend_SEQ
minvalue 1
maxvalue 9999999999
increment by 1
cache 20;

create or replace trigger tri_SMSSend
before insert on SMSSend
for each row
  begin
    select SMSSend_SEQ.Nextval into :new.id from dual;
    end;
