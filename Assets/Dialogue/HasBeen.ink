INCLUDE globals.ink

#rightAnswer:false

-> main

=== main ===
Wait, it all uchihas?
    * [Always has been]
        Oh, fuck
        -> rightAnswer
    * [Это огород]
        Что выращиваем?
        **[Шаринган]
        Бля
        -> DONE
    * [Чел, это другая вселенная]
        Понял, сваливаем.
        -> DONE
        
=== rightAnswer ===
Take money bro #rightAnswer:true

-> END