INCLUDE globals.ink

#rightAnswer:false

-> main

=== main ===
Ты уже вернул Саске?
    * [Да]
        Спасибо тебе большое, давай я тебя отблагодарю?
        ** [Знакомы?]
        ...
        -> rightAnswer
    * [Саске мой]
        Aртур, всё ок? 
        -> DONE
    * [ У него своя тусовка, так что он не вернётся]
        Hее-еее-е-ее-е-е-ееееет((((
        -> DONE
        
=== rightAnswer ===
Take money bro #rightAnswer:true

-> END