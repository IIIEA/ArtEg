INCLUDE globals.ink

#rightAnswer:false

-> main

=== main ===
Oh shit, i'm sorry
    * [Извини за что?]
        ...
        ** [Знаешь, отец учил не стыдиться своих членов]
        ...
        *** [Особенно когда они такого хорошего размера]
        Да, размерчик что надо. Батя у тебя умный мужик
        -> rightAnswer
    * [Извиняю]
        Еблан?
        -> DONE
    * [Ты кто?]
        После таких вопросов иди как ты нахуй, но не на мой
        -> DONE
        
=== rightAnswer ===
Take money bro #rightAnswer:true

-> END