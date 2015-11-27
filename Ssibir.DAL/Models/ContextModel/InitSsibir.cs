﻿using Ssibir.DAL.Models;
using Ssibir.DAL.Models.Context;
using Ssibir.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DevOne.Security.Cryptography.BCrypt;
using System.Data.Entity.Validation;

namespace Ssibir.DAL.Models.ContextModel
{
	public class InitSsibir : DropCreateDatabaseIfModelChanges<DbCatalog>
	//public class InitSsibir : DbMigrationCofiguration<DbCatalog>
    {

		//public InitSsibir()
		//{
		//	AutomaticMigrationEnable = true;
		//}

        private readonly string salt = BCryptHelper.GenerateSalt();

        protected override void Seed(DbCatalog context)
        {
			Guid ItalyId = Guid.NewGuid();
			string ItalyHtml = @"<span>Италию не зря называют страной-музеем, ведь именно здесь сосредоточены три четверти культурного достояния Европы. Но музеи замкнуты и единообразны, а Италия состоит из множества областей и городов с живой культурой, яркой историей и уникальными традициями. Каждый из них по праву считает себя особенным и гордится этим.
				Туры в Италию позволят побывать в совершенно разных регионах страны: на горнолыжных курортах в снежных Альпах и Доломитах, в галереях и винодельнях Тосканы и Эмили-Романьи, в роскошных магазинах Рима и Милана, в колоритных и уютных отелях Искьи и Сицилии, на курортах Фьюджи и Абано-Терме.
				Эта страна с богатейшей историей не оставит равнодушной ни одного туриста. Отдых в Италии – одно из тех удовольствий, которое хочется повторять снова и снова.</span>";
			string ItalyPretext = @"Италию не зря называют страной-музеем, ведь именно здесь сосредоточены три четверти культурного достояния Европы.";

			Guid VenecId = Guid.NewGuid();
			string VenecHtml = @"<span>В 30 км от Венеции расположился популярный курорт Лидо-ди-Езоло, отличающийся повышенной комфортностью и особыми, благоприятными природными условиями. Линии небольших чрезвычайно уютных отелей вытянуты вдоль моря и окружены разнообразными магазинами, кафе, ресторанами, пиццериями. От самой удалённой от моря гостиницы до воды не более 200–300 м. Отели первой линии находятся прямо на пляже и отделены от второй линии неширокой дорогой. Главная автомобильная магистраль проходит позади курорта.
					Высокий уровень обслуживания, изысканная итальянская кухня, большой выбор развлечений привлекают в Лидо-ди-Езоло людей всех возрастных категорий.</span>";
			string VenecPretext = @"Курорт Лидо-ди-Езоло уютно расположился на севере Аппенинского полуострова, у самого берега Адриатического моря. Благодаря тому, что он окружен Альпами, здесь никогда не бывает штормов и ветров, а достаточно мелководное море у берегов Лидо-ди-Езоло в летние месяцы может прогреваться до +25 °C. Вообще купальный сезон здесь начинается с конца весны, и длится приблизительно четыре с половиной месяца. Именно в это время сюда приезжает огромное количество туристов со всей Европы.";

			string oaeViza = @"<div class='content'>	 
					<span class='newsdateheader'>29 июля 2014, 13:19</span>
					<br><br>
					<p id='newsitembody'>В <a title='Объединенные Арабские Эмираты' href='http://guide.travel.ru/uae/'>ОАЭ</a> созданы механизмы для постепенного ввода новой визовой системы. К настоящему времени уже закончена подготовка онлайн-сервиса, и в ближайшие дни на сайте МВД страны появятся новые тарифы на визы, сообщает соб.корр. Travel.ru.
 					</p><p>На следующем этапе соискателям станут доступны <a title='Визы в ОАЭ' href='http://guide.travel.ru/uae/formalities/visas/'>новые типы виз</a>: многократная для посетителей и бизнесменов, виза для лечения или учебы, виза для участия в конференциях и так далее. Нововведения позволят улучшить качество услуг в туристической и социальной сфере сфере, а также сделают работу МВД и иммиграционной службы более эффективной. Туристов же в первую очередь порадует возможность получения многократной визы.
 					</p><p>В дополнение к этому на сайте МВД ОАЭ сообщается, что благодаря внедрению системы e-service у туристов и граждан ОАЭ появятся следующие возможности:
					</p><ul>
					<li> подача заявлений на разрешение на въезд или постоянное жительство и оплата сборов через интернет;
					</li><li> получение подтверждений для въезда или вида на жительство через интернет;
					</li><li> получение уведомлений и информации через SMS и по электронной почте;
					</li><li> обслуживание клиентов колл-центрами в течение 24 часов 7 дней в неделю;
					</li><li> использование сенсорных экранов в разных визовых центрах в ОАЭ для печати виз и проведения транзакций.
					</li></ul> 
					<p>Кроме того, на сайте визового центра эмирата Дубай уже появилась <a title='Страница откроется в новом окне' href='http://www.dubaivisa.net/online.html' target='_blank' rel='nofollow'>возможность зарегистрироваться</a> и подать заявление онлайн. Соискателю потребуется заполнить анкету, предоставить копию паспорта и фотографию. Здесь же есть возможность отследить статус отправленной заявки.
					</p>  
					</div>	 
					</div>";

			Guid pattongId = Guid.NewGuid();
			string pattongHtml = @"<span style='color:#000000;'><strong>Знаменитый пляж Патонг на популярном у туристов острове Пхукет возвращён к своей первозданной чистоте. Программа по очистке пляжа была инициирована в начале месяца Национальным Советом для Мира и Порядка Таиланда.</strong></span>
				<p>Патонг находится на западном побережье острова Пхукет и сегодня является одним из самых любимых мест отдыха среди туристов во всём Таиланде. Такую популярность Патонг заслужил благодаря белоснежному песку, великолепным закатам и яркой ночной жизни. Но в последние годы пляж стал очень многолюдным из-за торговцев.</p>
				<p>«В рамках программы по очистке пляжа, проводившейся под руководством Национального Совета для Мира и Порядка, с пляжа были убраны мешающие свободному передвижению киоски с едой, массажные хижины и другие нелегальные киоски, – сообщил <span style='color:#000000;'><strong>глава туристического Управления Таиланда Таватчай Аруньик. </strong></span>– Теперь каждый гость пляжа может насладиться его первозданным видом».</p>
				<p>В середине июля власти осмотрели всю территорию 3,5-километрового пляжа, чтобы убрать с неё нелегальные постройки и сооружения в рамках программы по улучшению образа страны и впечатлений туристов, приезжающих на Пхукет.</p>
				<p>Очистка пляжа стала последней из мер, предпринятых Национальным Советом для улучшения впечатлений путешественников, как местных, так и иностранных, которые посещают различные <a href='/tags/303'>достопримечательности</a> Таиланда. В дальнейшем на Пхукете планируется провести аналогичные акции по очистки четырёх других пляжей, а также запретить нелегальные такси.</p>
				<p>Другие меры предпринимаются в Бангкоке, где полным ходом идёт процесс оснащения компьютерами очередей к такси в международном аэропорту Суварнабхуми, в то время как в Паттайе также идёт очистка пляжей.</p>";
			string pattongPretext = @"Знаменитый тайский пляж Патонг встречает туристов после капитальной уборки";

			Guid czClassicId = Guid.NewGuid();
			string czClassic = @"<div class='content'>
						<p><strong>В стоимость входит:</strong></p>
						<ul>
						<li>Авиаперелет Новосибирск — Прага — Новосибирск</li>
						<li>Проживание в отеле с завтраком (длительность в зависимости от выбранной программы)</li>
						<li><strong>Экскурсионная программа:</strong></li>
						</ul>
						<p>&nbsp; &nbsp; &nbsp;- Обзорная экскурсия по Старому городу и Пражскому Граду (возможно объединение экскурсий в один день на усмотрение принимающей компании, дата проведения согласовывается на месте)<br>&nbsp; &nbsp; &nbsp; &nbsp; - Экскурсия в Карловы Вары (день проведения: вторник)<br>&nbsp; &nbsp; &nbsp; &nbsp; - После экскурсии в Карловы Вары - экскурсия с вечерней прогулкой по Малой Стране с ужином и дегустацией вин в Большом Монастырском ресторане<br>&nbsp; &nbsp; - Экскурсия в замок Мелник с осмотром винных погребов, дегустацией вина и обедом (день &nbsp; проведения: воскресенье)</p>
						<ul>
						<li>Трансферы по программе (групповой трансфер предоставляется только под рейсы S7 857/858)</li>
						<li>Медицинская страховка с покрытием 30 000 евро &nbsp;</li>
						</ul>
						<p><span>&nbsp;</span><strong>Дополнительно оплачивается:</strong></p>
						<ul>
						<li>Виза 80 евро — взрослые, дети до 6 лет - бесплатно, стоимость срочной визы - 130 евро</li>
						<li>Страховка от невыезда (обязательно) — 2,5 % от стоимости тура (в случае отказа от страховки необходимо заполнить форму &nbsp;)</li>
						<li>Дополнительно можно заказать групповые экскурсии&nbsp;</li>
						</ul>
						<p>&nbsp;</p>
						<ul>
						</ul>
						<p>&nbsp;</p>
						<ul type='disc'>
						</ul>
                    </div>";

            Guid antaliaId = Guid.NewGuid();
            string antaliaPre = @" Анталия — большой, современный, быстроразвивающийся город, расположенный всего в 12 км от аэропорта. Здесь развитая сеть современных отелей, множество ресторанчиков, кофеен в национальном стиле, всевозможных развлекательных центров и дискотек, бесчисленные магазины, аквапарки. Вообще, Анталия&nbsp;— скорее городской курорт, нежели пляжный. Большинство отелей здесь&nbsp;— городского типа. Одни, расположенные в районе Коньяалти, пользуются муниципальным пляжем с крупной белой галькой, другие, находящиеся в центральной скалистой части, используют пляжи-платформы. Третьи же, построенные в районе Лара и Кунду, имеют собственные песчаные пляжи.";
            string antaliaHtml = @"<div>
                <p>
                    Анталия — большой, современный, быстроразвивающийся город, расположенный всего в 12 км от аэропорта. Здесь развитая сеть современных отелей, множество ресторанчиков, кофеен в национальном стиле, всевозможных развлекательных центров и дискотек, бесчисленные магазины, аквапарки. Вообще, Анталия&nbsp;— скорее городской курорт, нежели пляжный. Большинство отелей здесь&nbsp;— городского типа. Одни, расположенные в районе Коньяалти, пользуются муниципальным пляжем с крупной белой галькой, другие, находящиеся в центральной скалистой части, используют пляжи-платформы. Третьи же, построенные в районе Лара и Кунду, имеют собственные песчаные пляжи.
                </p>
                <h2> Как добраться </h2>
                <p>
                    В международный аэропорт Анталии в течение сезона летает множество чартеров из разных регионов России. Примерное время трансфера зависит от расположения отеля&nbsp;— от 20 минут до часа.
                </p>
                <h2> Шоппинг: магазины </h2>
                <p>
                    Самые шикарные магазины расположены на улице Ататюрка (Ататюрк-джаддеси).
                </p>
                <h2> Кухня и рестораны Анталии</h2>
                <p>
                    В Анталии туристам обязательно стоит посетить рыбный ресторан и заказать рыбу «грида». Она водится только в Средиземном море и имеет неповторимый вкус. Ее запекают в соли и в таком виде подают на стол. По желанию клиентов официант может предварительно очистить ее от костей.
                </p>
                <h2> Кухня и рестораны Анталии</h2>
                <p>
                    В Анталии туристам обязательно стоит посетить рыбный ресторан и заказать рыбу «грида». Она водится только в Средиземном море и имеет неповторимый вкус. Ее запекают в соли и в таком виде подают на стол. По желанию клиентов официант может предварительно очистить ее от костей.
                </p>
                <h2>Обзорная экскурсия по Анталии</h2>
                <p>
                    Обычно в стоимость тура на анталийское побережье включают одну экскурсию, которую называют «обзорной по городу». На самом деле познавательного в ней немного&nbsp;— туристов сперва везут в «кожаный центр» (огромный склад изделий из кожи далеко за чертой города), затем в «текстильный центр», потом&nbsp;— в «ювелирный центр». Далее следует бесплатный обед в удалённом от цивилизации заведении (напитки платные) и лишь в самую последнюю очередь&nbsp;— посещение водопада Дуден, единственный познавательный элемент программы.
                </p>
                <h2> Развлечения, экскурсии и достопримечательности Анталии</h2>
                <p>
                    Популярные достопримечательности Анталии - Ворота Адриана, воздвигнутые в честь посещения города римским императором, символ города&nbsp;— мечеть Йивли с высоченным минаретом, парки Мермели и Караалайоглу, башни Кале-Капысы и Хыдырлык, мечети Искеле и Мехмет-Паша, караван-сарай Сельджук-Хан, часовая башня Саат-Кулеси. Из музеев более всего интересны Археологический, дом-музей Ататюрка и этнографический музей Суны.
                    Рядом с городом расположены два национальных парка: Дюденские водопады и водопады Куршунлу. В 30&nbsp;км от Анталии находятся пещеры Караин, одни из самых больших в стране.
                </p>
                <p>
                    В Анталии огромное количество баров, ресторанов и развлекательных комплексов, а также два аквапарка, оба&nbsp;— с весьма изобретательными названиями: Aqualand и Aquapark, плюс не менее креативно именованный дельфинарий Dolphinland.
                </p>
                <p>
                    Самой «зажигательной» можно назвать дискотеку «Олимпос» при отеле «Шератон Фалез». Ночью под открытым небом туристы веселятся в «Клубе 29» одноимённого отеля (более сдержанно) и на пляже Коньяалти (совсем отвязно). Недалеко от «Клуба 29» в старом городе есть ещё одна дискотека, более дорогая и престижная. «Танец живота» можно увидеть по средам и воскресеньям в отеле «Талья» на улице Февзи Джакмак. Ночью «Аквалэнд» в Анталии превращается в «Дисколэнд», где можно совместить катание на водных горках и танцы до утра.
                </p>
                <div>
                    <span>9 вещей, которые надо сделать в Анталии</span>
                    <ol>
                        <li>
                            Проникнуться древней историей этих мест, стоя рядом с воротами императора Адриана.
                        </li>
                        <li>
                            Забравшись на смотровую площадку, взглянуть на минарет Йивли необычного внешнего вида.
                        </li>
                        <li>
                            Тряхнуть стариной, ну или еще чем-нибудь, на дискотеке «Олимпус».
                        </li>
                        <li>
                            Из местного порта отправиться на экскурсию к водопадам Дюден: под Верхним находится просторная карстовая пещера, а Нижним хорошо любоваться с борта прогулочной яхты.
                        </li>
                        <li>
                            Непременно побывать в аквапарке: в самом популярном — «Акваленд», или в любом другом.
                        </li>
                        <li>
                            Погрузиться в старину и древность в археологическом музее — самом любопытном заведении подобного рода в Анталии.
                        </li>
                        <li>
                            Вообразить себя Гулливером в стране лилипутов, прохаживаясь по мини-городу — парку, представляющему все достопримечательности Турции, уменьшенные в 25 раз.
                        </li>
                        <li>
                            Прогуляться мимо пирамиды Сабанчи — сооружения из стекла и металла грандиозных размеров. Это самое современное здание в Анталии.
                        </li>
                        <li>
                            Не пропустить Шоу фонтанов — самое зрелищное представление вечернего города.
                        </li>
                    </ol>
                </div>
            </div>";

			var bestManager = @"<div class='content'>
					<h2>Лучший менеджер по туризму в США</h2>
					<p><span style='color: rgb(51, 51, 51); font-family: Arial, Verdana, Arial;'>По традиции, менеджеры туристических компаний, набравшие проходной балл, получили дипломы различных категорий от АТОР и VisitUSA. Лучше всех с заданиями Аттестации справились Валерия Жаркова из компании «Лингвомир», Светлана Ибрагимова из агентства «Праздник Трэвэл» и Елена Соколова, менеджер туркомпании «Столица Сибири», получившая главный приз – авиаперелет в Соединенные Штаты Америки</span></p>
					<p><a href='http://www.atorus.ru/certification/att_news/new/21430.html'><span style='color: rgb(51, 102, 255);'>http://www.atorus.ru/certification/att_news/new/21430.html</span></a></p>

					<p>Российский турпоток в США каждый год &nbsp;увеличивается. Этому способствует как лояльная визовая политика страны, так и увеличивающееся количество прямой регулярной авиаперевозки из нашей страны. Уже сейчас россияне могут летать из Москвы напрямую в Нью-Йорк, Майями, Лос-Анджелес.</p>
					<p>С ростом спроса на американское направление, возрастает и потребность в квалифицированных тревел-консультантах. Свои знания на Аттестации решились проверить более 40 менеджеров турфирм. Им было предложено ответить на ряд вопросов на знание географии и культуры страны, а также на вопросы-ситуации.</p>
					<p>Неожиданно мозговой штурм турагентов был прерван визитом посла США в РФ Майкла Макфола. Участники Аттестации смогли побеседовать с г-ном Макфолом, задать ему интересующие их вопросы. Некоторые даже попытались привлечь посла к решению заданий экзамена. Г-н Макфол изучил опросный лист и пошутил: 'Да я сам знаю меньше, чем вы!'.</p>
					<p>Майкл Макфол высоко оценил желание сотрудников турфирм повышать свой профессиональный уровень с помощью Аттестации АТОР. 'Мы всегда поддерживаем &nbsp;туризм. Он улучшает нашу экономику, и мы очень рады, что большое количество &nbsp;туристов приезжает в нашу страну. Очень важно, что когда человек приезжает в страну как турист, он меняет свой взгляд на нее в лучшую сторону. Лично я впервые выехал за границу 30 лет назад и это был Советский Союз. Я много читал о Ленинграде, но в первый же день пребывания там, я изменил свой взгляд на этот город и вашу страну. Каждый раз, когда я встречаю людей, которые съездили в Америку, я вижу изменения в их отношении к стране. Поэтому даже нам, дипломатам, туристическая деятельность помогает делать свою работу', - отметил в ходе беседы с 'Вестником АТОР' Майкл Макфол.</p>
					<p><span style='color: rgb(51, 51, 51); font-family: Arial, Verdana, Arial;'>По традиции, менеджеры туристических компаний, набравшие проходной балл, получили дипломы различных категорий от АТОР и VisitUSA. Лучше всех с заданиями Аттестации справились Валерия Жаркова из компании «Лингвомир», Светлана Ибрагимова из агентства «Праздник Трэвэл» и Елена Соколова, менеджер туркомпании «Столица Сибири», получившая главный приз – авиаперелет в Соединенные Штаты Америки</span></p>
					<p>&nbsp;</p>  </div>";


			string WMCostAnalyzePre = @"Женщины чаще склонны выбирать более дорогие отели, в то время как мужчины обычно предпочитают более экономичные варианты размещения на отдыхе – таков результат исследования потребительских предпочтений";
			string WMCostAnalyzeHtml = @"<div>
			    <p>Женщины чаще склонны выбирать более дорогие отели, в то время как мужчины обычно предпочитают более экономичные варианты размещения на отдыхе – таков результат исследования потребительских предпочтений, проведенного исследовательской компанией GFK по заказу туроператора <a href='http://www'tourprom'ru/company/tui/'>TUI Россия</a>' Опрашивались респонденты из Москвы и Санкт-Петербурга' Цель исследования – выявить, как принимают решение и что ожидают от отдыха разные группы целевой аудитории TUI Россия'</p>
			    <p>Согласно результатам исследования, 39% респондентов женского пола чаще бронируют туры в пятизвездочные отели' Мужчинам не так важна высокая категория отеля, они чаще предпочитают более экономичные трехзвездочные отели (38% респондентов мужского пола)' При этом интерес к отелям категории 4*, которые часто предлагаю хорошее соотношение цена/качество, одинаково высок как со стороны женщин (55%), так и со стороны мужчин (56%)'</p>
			    <p>Кстати, пятизвездочные отели пользуются большей популярностью среди семейных туристов, а также среди тех, кто по разным причинам больше не состоит в браке (39 и 45% соответственно)' Не состоящие в браке респонденты, проживающие с родственниками, чаще выбирают отели 4* (60%)' Туристы, не состоящие в браке и живущие отдельно от родственников, предпочитают более экономичные варианты размещения с категорией 3* (63% респондентов этой группы)'</p>
			    <p>Более дешевые варианты размещения на отдыхе (отели 2*) чаще других выбирает молодежь (18 - 25 лет; 14%) и представители старшего поколения (56 - 70 лет; 16%)'</p>
			    <p>Как сообщили корреспонденту инфогруппы «ТУРПРОМ» в пресс-службе туроператора, на основе полученных результатов будет сформирована продуктовая линейка туроператора на 2015 год' Изучив данные исследования, компания выбрала несколько дифпродуктов группы TUI, которые отвечают потребностям российских туристов' Уже летом 2015 года компания представит на российский рынок сети отелей: Sensatori (отдых премиального уровня), Sensimar (отдых специально для пар), Robinson (сеть отелей для активного отдыха), Suneo Club (подборка отелей 'все включено' по максимально доступной цене) и др'</p>
		    </div>";

			var clients = new List<Client>
                          {
                              new Client()
                                {
                                    Id = Guid.NewGuid(),
                                    Birth = DateTime.Now.AddYears(-12),
                                    FirstName = "Client",
                                    Login = "a",
                                    Password = BCryptHelper.HashPassword("aaa", salt)
                                }
                          };
            clients.ForEach(d => context.Clients.Add(d));

			var dirData = new initDataDirection();

			List<Direction> dirs = dirData.GetDirectios();
			dirs.ForEach(d => context.Directions.Add(d));

            var tours = new List<Tour>
                          {
                            new Tour() { Id = antaliaId, Title = "Анталия", Cost = 28000, Type = TourType.Beach, isHot = true },
                            new Tour() { Id = ItalyId, Title = "Италия", Cost = 32000, Type = TourType.Culture, isHot = true },
                            new Tour() { Id = czClassicId, Title = "Чехия классическая", Cost = 35000, Type = TourType.Individual, isHot = true },
                            new Tour() { Id = pattongId, Title = "Паттонг", Cost = 24000, Type = TourType.Culture, isHot = true },
                            new Tour() { Id = VenecId, Title = "Венеия", Cost = 43000, Type = TourType.Other, isHot = true }
                          };
            tours.ForEach(d => context.Tours.Add(d));

            var ms = new List<Manager>
                          {
                              new Manager()
                                {
                                     Id = Guid.NewGuid(),
                                     Login="m",
									 Job = JobGrid.Director,
                                     Password = BCryptHelper.HashPassword("mmm", salt),
                                     LastName = "Соколова",
                                     FirstName ="Елена",
									 Email = "s5sibir@yandex.ru",
									 Phone = "89137040184",
									 Skype = "sokolova.elena2",
									 Description = "Генеральный Директор, специалист по круизам, специалист по США",
									 key = "SokolovaElena"
                                },
                             new Manager()
                                {
                                     Id = Guid.NewGuid(),
                                     Login="s",
                                     Password = BCryptHelper.HashPassword("mmm", salt),
                                     LastName = "Соколов",
                                     FirstName ="Алексей",
									 Job = JobGrid.MidManager,
									 Email = "s77sibir@yandex.ru",
									 Phone = "89139277868",
									 Skype = "ierroglif",
									 Vk = "http://vk.com/id701209",
									 Description = "Специалист по Европе",
									 key = "SokolovAlex"
                                },
							new Manager()
                                {
                                     Id = Guid.NewGuid(),
                                     Login="e",
									 Job = JobGrid.commercialDirector,
                                     Password = BCryptHelper.HashPassword("mmm", salt),
                                     LastName = "Соколов",
                                     FirstName ="Евгений",
									 Description = "Специалист по Азии",
									 key = "SokolovEvgeniy"
                                },
							new Manager()
                                {
                                     Id = Guid.NewGuid(),
                                     Login="alina",
									 Job = JobGrid.SeniorManager,
                                     Password = BCryptHelper.HashPassword("mmm", salt),
                                     LastName = "Соколова",
                                     FirstName ="Алина",
									 Description = "Специалист по авиаперелетам",
									 key = "SokolovaAlina"
                                },
							new Manager()
                                {
                                     Id = Guid.NewGuid(),
                                     Login="i",
									 Job = JobGrid.MidManager,
                                     Password = BCryptHelper.HashPassword("mmm", salt),
                                     LastName = "Соколова",
                                     FirstName ="Ирина",
									 Vk = "http://vk.com/naumenko",
									 Description = "Специалист по США",
									 key = "SokolovaIrina"
                                }
                          };
            ms.ForEach(d => context.Managers.Add(d));

            var pages = new List<Page>
                          {
							new Page()
								{
									CreatedDate = DateTime.Now,
									CreatedById =  ms.FirstOrDefault().Id,
									Type = Enum.PageType.Manager,
									key = "SokolovaElena"
								},
							new Page()
								{
									CreatedDate = DateTime.Now,
									CreatedById =  ms.FirstOrDefault().Id,
									Type = Enum.PageType.Manager,
									key = "SokolovaIrina"
								},
							new Page()
								{
									CreatedDate = DateTime.Now,
									CreatedById =  ms.FirstOrDefault().Id,
									Type = Enum.PageType.Manager,
									key = "SokolovaAlina"
								},
							new Page()
								{
									CreatedDate = DateTime.Now,
									CreatedById =  ms.FirstOrDefault().Id,
									Type = Enum.PageType.Manager,
									key = "SokolovEvgeniy"
								},
							new Page()
								{
									CreatedDate = DateTime.Now,
									CreatedById =  ms.FirstOrDefault().Id,
									Type = Enum.PageType.Manager,
									key = "SokolovAlex"
								},
							new Page()
								{
									CreatedDate = DateTime.Now,
									Title = "Италия",
									CreatedById =  ms.FirstOrDefault().Id,
									Type = Enum.PageType.Hot,
									TourId = ItalyId,
									key = "Italy",
									Html = ItalyHtml,
									PreText = ItalyPretext
								},
							  new Page()
								{
									CreatedDate = DateTime.Now,
									Title = "Венецианская ривьера",
									CreatedById =  ms.FirstOrDefault().Id,
									Type = Enum.PageType.Hot,
									TourId = VenecId,
									key = "Venec",
									Html = VenecHtml,
									PreText = VenecPretext
								},
							  new Page()
								{
									CreatedDate = DateTime.Now,
									Title = "Чехия классическая",
									CreatedById =  ms.FirstOrDefault().Id,
									Type = Enum.PageType.Hot,
									TourId = czClassicId,
									key = "czClassic",
									Html = czClassic,
									PreText = @"Авиаперелет Новосибирск — Прага — Новосибирск
												Проживание в отеле с завтраком (длительность в зависимости от выбранной программы)
												Экскурсионная программа"
								},
								new Page()
								{
									CreatedDate = DateTime.Now,
									Title = "Анталия",
									Html = antaliaHtml,
									TourId = antaliaId,
									key = "antalia",
									PreText = antaliaPre, 
                                    CreatedById = ms.FirstOrDefault().Id,
									Type = Enum.PageType.Hot,
									Priority = 100
								},
                                 new Page()
                                {
                                    CreatedDate = DateTime.Now,
                                    Title = "В ОАЭ будут введены новые типы виз",
                                    Html = oaeViza,
                                    PreText = "В ОАЭ созданы механизмы для постепенного ввода новой визовой системы.",
                                    key = "oaeViza",
									CreatedById =  ms.FirstOrDefault().Id,
                                    Type = Enum.PageType.News,
                                    Priority = 101,
                                    IsManual = true
                                },
                                 new Page()
                                {
                                    CreatedDate = DateTime.Now,
                                    Title = "Новый Патонг",
                                    Html = pattongHtml,
                                    PreText = pattongPretext,
                                    key = "newPatong",
									CreatedById =  ms.FirstOrDefault().Id,
                                    Type = Enum.PageType.News,
                                    Priority = 102,
                                    IsManual = true
                                },
                                 new Page()
                                {
                                    CreatedDate = DateTime.Now,
                                    Title = "Посол США высоко оценил...",
                                    Html = bestManager,
                                    key = "bestManager",
									PreText = "По традиции, менеджеры туристических компаний, набравшие проходной балл, получили дипломы различных категорий от АТОР и VisitUSA. Лучше всех с заданиями Аттестации справились Валерия Жаркова из компании «Лингвомир», Светлана Ибрагимова из агентства «Праздник Трэвэл» и Елена Соколова, менеджер туркомпании «Столица Сибири», получившая главный приз – авиаперелет в Соединенные Штаты Америки",
                                    CreatedById =  ms.FirstOrDefault().Id,
                                    Type = Enum.PageType.News,
                                    Priority = 104,
                                    IsManual = true
                                },
								new Page()
                                {
                                    CreatedDate = DateTime.Now,
                                    Title = "Исследование «TUI»: туристки выбирают более дорогие отели, чем туристы.",
                                    Html = WMCostAnalyzeHtml,
                                    key = "WMCostAnalyze",
									PreText = WMCostAnalyzePre,
                                    CreatedById =  ms.FirstOrDefault().Id,
                                    Type = Enum.PageType.News,
                                    Priority = 105,
                                    IsManual = true
                                }
                          };
            pages.ForEach(d => context.Pages.Add(d));

			List<Page> dirPages = dirData.GetDirectionPages();
			dirPages.ForEach(d => context.Pages.Add(d));

			List<Page> tourPages = dirData.GetDirectionPages();
			dirPages.ForEach(d => context.Pages.Add(d));


			var toursData = new initDataTours();
			List<Tour> otherTours = toursData.GetTours();
			otherTours.ForEach(d => context.Tours.Add(d));
			List<Page> otherTourPages = toursData.GetTourPages();
			otherTourPages.ForEach(d => context.Pages.Add(d));

            var op = new List<Operator>
                          {
                              new Operator()
                                {
                                     Id = Guid.NewGuid(),
                                     Title = "TEZ" 
                                }
                          };
            op.ForEach(d => context.Operators.Add(d));

			try
			{
				context.SaveChanges();
			}
			catch (DbEntityValidationException ex)
			{
				throw(ex);
			}
            
        }
    }
}