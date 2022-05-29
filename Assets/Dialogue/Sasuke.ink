INCLUDE globals.ink

#rightAnswer:false

-> main

=== main ===
Итачи плохой
    * [Согласен]
        Но он мой брат
        ** [Понимаю]
        Или может всё таки хороший
        *** [Да иди ты нахуй]
        -> rightAnswer
    * [Нет]
        Я должен его убить
        -> DONE
    * [Просто денег дай и я уйду]
        Чидори
        -> DONE
        
=== rightAnswer ===
НАРУТООООО #rightAnswer:true

-> END