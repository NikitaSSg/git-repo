using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Black_Jack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var pack = [2, 3, 4, 5, 6, 7, 8, 9, 10, 'J', 'Q', 'K', 'A'];
            var Dealer = [];
            var Player = [];
            
            function getRandomInt(min, max) //случайное целое число от min до max

    {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }
            

            function removeArr(arr, value) //удаляет элемент из массива(здесь не используется, заготовка для будущего)

    {
                var val = arr.indexOf(value); //ищем индекс эл-та
                arr.splice(val, 1); //удаляем эл-т по индексу
            }

            function outScore()

    {
                return alert('Карты Дилера: ' + Dealer + ' Сумма: ' + scoreCard(Dealer) + '       Ваши карты: ' + Player + ' Сумма: ' + scoreCard(Player));
            }

            function getCard()

    {
                return pack[getRandomInt(0, pack.length - 1)];
            }

            function scoreCard(person) //подсчет карт для массивов игрока и дилера

    {
                var scoreperson = 0;
                var meterA = 0;
                for (var i = 0; i < person.length; i++)
                {
                    if ((typeof person[i]) == (typeof 1)) {
                    scoreperson = scoreperson + person[i];
                } else {
                    switch (person[i])
                    {
                        case 'J':
                        case 'Q':
                        case 'K':
                            scoreperson = scoreperson + 10;
                            break;
                        case 'A':
                            meterA = meterA + 1;
                            break;
                    }
                }
            }

            for (var iA = 0; iA < meterA; iA++)
            {
                if (scoreperson <= 10)
                {
                    scoreperson = scoreperson + 11;
                }
                else
                {
                    scoreperson = scoreperson + 1;
                }
            }
            return scoreperson;
        }


        //берём первоначальные карты
        Dealer.push(getCard());
Player.push(getCard(), getCard());

outScore();

if ((scoreCard(Player)) < 21) {
	//добор для игрока
	Player.push('| ');
	while (confirm('Ещё карту?')) {
		Player.push(getCard());
		if ((scoreCard(Player)) < 21) {

            outScore();
    } else if ((scoreCard(Player)) == 21) {

            alert('У вас 21!');
			break;
		} else {

            alert('У вас перебор!');

            outScore();
			break;
		}
		  
	}
} else if ((scoreCard(Player)) == 21) {

    alert('У вас Black Jack!');
}

//добор для дилера
if ((scoreCard(Player)) <= 21) {

    alert('Идет добор Дилера...');
Dealer.push('| ');
	while ((scoreCard(Dealer)) < 17) {
		Dealer.push(getCard());
	}
}

//who is win?!
if ((scoreCard(Player)) <= 21 && (scoreCard(Dealer)) <=21) {
	if ((scoreCard(Dealer)) == (scoreCard(Player)) ) {

        alert('Stay! Возврат ставки!');

        outScore();
	} else if ((scoreCard(Player)) < (scoreCard(Dealer))) {

        alert('You lose!');

        outScore();
	} else if ((scoreCard(Dealer)) < (scoreCard(Player))) {

        alert('You win!');

        outScore();
	}
} else if ((scoreCard(Dealer)) > 21) {

    alert('You win!');

    outScore();	
}

        }
    }
}
