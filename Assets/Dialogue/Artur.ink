INCLUDE globals.ink

#rightAnswer:false

-> main

=== main ===
Ты кто?
    * [Я это ты]
        Ты тоже Аянами Рэй?
        ** [Я Аянами Рэй]
        И я Аянами Рэй
        *** [Выходит мы оба Аянами Рэй]
        Получается так
        **** [Но я всё равно лучше]
        -> rightAnswer
    * [Миллиардер, филантроп, гений, плэйбой]
        ...
        -> DONE
    * [Гей]
        Сегодня в 8.00 приходи. Тусовка в главном здании.
        -> DONE
        
=== rightAnswer ===
Take money bro #rightAnswer:true

-> END