select MONTH_NAME, NUM, BANK_ACCOUNT_ID, sum(DEBIT) as DEBIT, Sum(CREDIT) as CREDIT, QUARTER_NUMBER, MONTH_NUMBER, YEAR_NUMBER, PR
from (select
             case extract(month from "Bank_Payments"."Payment_Date")
               when 1 then 'Січень'
               when 2 then 'Лютий'
               when 3 then 'Березень'
               when 4 then 'Квітень'
               when 5 then 'Травень'
               when 6 then 'Червень'
               when 7 then 'Липень'
               when 8 then 'Серпень'
               when 9 then 'Вересень'
               when 10 then 'Жовтень'
               when 11 then 'Листопад'
               when 12 then 'Грудень'
             end as MONTH_NAME,
             ACCOUNTS.NUM as NUM, "Bank_Payments"."Bank_Account_Id" as BANK_ACCOUNT_ID,

             -- FromPeriod
             -- DebitFromPeriod
             sum(iif("Bank_Payments"."Direction" = 1, COALESCE("Bank_Payments"."Payment_Price", 0), 0)) as DEBIT,
             -- CreditFromPeriod
             sum(iif("Bank_Payments"."Direction" = -1, COALESCE("Bank_Payments"."Payment_Price", 0), 0)) as CREDIT,
             (extract(month from "Bank_Payments"."Payment_Date") - 1) / 3 + 1 as QUARTER_NUMBER,
             extract(month from "Bank_Payments"."Payment_Date") as MONTH_NUMBER,
             extract(year from "Bank_Payments"."Payment_Date") as YEAR_NUMBER, 0 as PR
      from "Bank_Payments"
      left join ACCOUNTS on ACCOUNTS.ID = "Bank_Payments"."Purpose_Account_Id"
      where "Bank_Payments"."Bank_Account_Id" = @Bank_Account and
            "Bank_Payments"."Payment_Date" between @Start_Date and @End_Date
      group by "Bank_Payments"."Payment_Date", "Bank_Payments"."Bank_Account_Id", ACCOUNTS.NUM
      union all
      select 'EndPeriod' as MONTH_NAME, null as NUM, "Bank_Payments"."Bank_Account_Id" as BANK_ACCOUNT_ID,
             -- DebittEndPeriod
             sum(iif("Bank_Payments"."Direction" = 1,  COALESCE("Bank_Payments"."Payment_Price",0), 0)) as DEBIT,
             -- CreditEndPeriod
             sum(iif("Bank_Payments"."Direction" = -1, COALESCE("Bank_Payments"."Payment_Price",0), 0)) as CREDIT,
             null as QUARTER_NUMBER, null as MONTH_NUMBER,
             null as YEAR_NUMBER, 2 as PR
      from "Bank_Payments"
      where "Bank_Payments"."Bank_Account_Id" = @Bank_Account and
            "Bank_Payments"."Payment_Date" <= @End_Date
      group by "Bank_Payments"."Bank_Account_Id"
      union all
            select 'PrewPeriod' as MONTH_NAME, null as NUM, "Bank_Payments"."Bank_Account_Id" as BANK_ACCOUNT_ID,

             -- DebitPrewPeriod
             sum(iif("Bank_Payments"."Direction" = 1, COALESCE("Bank_Payments"."Payment_Price",0), 0)) as DEBIT,
             -- CreditPrewPeriod
             sum(iif("Bank_Payments"."Direction" = -1, COALESCE("Bank_Payments"."Payment_Price",0), 0)) as CREDIT,
             null as QUARTER_NUMBER, null as MONTH_NUMBER,
             null YEAR_NUMBER, 3 as PR
      from "Bank_Payments"
      where "Bank_Payments"."Bank_Account_Id" = @Bank_Account and
            "Bank_Payments"."Payment_Date" < @Start_Date
      group by "Bank_Payments"."Bank_Account_Id"
     union all
      select 'FromPeriod' as MONTH_NAME, null as NUM, "Bank_Payments"."Bank_Account_Id" as BANK_ACCOUNT_ID,
             -- DebitFromPeriod
             sum(iif("Bank_Payments"."Direction" = 1, COALESCE("Bank_Payments"."Payment_Price",0), 0)) as DEBIT,
             -- CreditFromPeriod
             sum(iif("Bank_Payments"."Direction" = -1, COALESCE("Bank_Payments"."Payment_Price",0), 0)) as CREDIT,
             null as QUARTER_NUMBER, null as MONTH_NUMBER,
             null as YEAR_NUMBER, 1 as PR
      from "Bank_Payments"
      where "Bank_Payments"."Bank_Account_Id" = @Bank_Account and
           "Bank_Payments"."Payment_Date" between @Start_Date and @End_Date
      group by "Bank_Payments"."Bank_Account_Id")
      group by  MONTH_NAME, NUM, BANK_ACCOUNT_ID,QUARTER_NUMBER, MONTH_NUMBER, YEAR_NUMBER, PR
order by PR, YEAR_NUMBER, MONTH_NUMBER, QUARTER_NUMBER

