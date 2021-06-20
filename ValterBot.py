import discord
from discord.ext import commands
from discord.utils import get
import random
import asyncio

PREFIX = "."
intents = discord.Intents.default()
intents.members = True
bot = commands.Bot(command_prefix=PREFIX, intents=intents)
bot.remove_command('помощь')
client = discord.Client()


@bot.event
async def on_ready():
    print("ready")
    await bot.change_presence(activity=discord.Activity(
        type=discord.ActivityType.watching, name="за вами)"))


@bot.command()
async def помощь(ctx, *, helpwho=None):
    if helpwho is None:
        emb = discord.Embed(color=0xffaa00, title="Возможные команды:\n")
        emb.add_field(
            name=f"Информация ({PREFIX}помощь инфо)",
            value=f"`{PREFIX}помощь`  `{PREFIX}юзер` `{PREFIX}сервер`",
            inline=False)
        emb.add_field(
            name=f"Модерация ({PREFIX}помощь модер)",
            value=
            f'`{PREFIX}бан` `{PREFIX}разбан` `{PREFIX}кик` `{PREFIX}мут` `{PREFIX}размут` `{PREFIX}очистить` `{PREFIX}пред` `{PREFIX}снятьпред`',
            inline=False)
        emb.add_field(name=f"Утилиты ({PREFIX}помощь утилиты)",
                      value=f"`{PREFIX}вычислить` `{PREFIX}рандом` `{PREFIX}аватар`",
                      inline=False)
        emb.add_field(name=f"Весёлости ({PREFIX}помощь веселье)",
                      value=f"`{PREFIX}тест` `{PREFIX}кубик` `{PREFIX}бар`",
                      inline=False)
    elif helpwho == 'модер':
        emb = discord.Embed(color=0xffaa00,
                            title="Доступные команды раздела `МОДЕРАЦИЯ`:\n")
        emb.add_field(name=f"`{PREFIX}бан`",
                      value=f"Заблокировать и выгнать участника с сервера\nПример: `{PREFIX}бан <участник> [причина]`",
                      inline=False)
        emb.add_field(name=f"`{PREFIX}разбан`",
                      value=f"Разблокировать участника\nПример: `{PREFIX}разбан <участник>`",
                      inline=False)
        emb.add_field(name=f"`{PREFIX}кик`",
                      value=f"Выгнять участника с сервера\nПример: `{PREFIX}кик <участник> [причина]`",
                      inline=False)
        emb.add_field(
            name=f"`{PREFIX}мут`",
            value=f"Не даёт писат в чаты участнику на определенное время\nПример: `{PREFIX}мут <участник> [причина]`")
        emb.add_field(name=f"`{PREFIX}размут`",
                      value=f"Снимает ограничения с участника\nПример: `{PREFIX}размут <участник>`",
                      inline=False)
        emb.add_field(name=f"`{PREFIX}очистить`",
                      value=f"Очистить сообщения с канала\nПример: `{PREFIX}очистить <количество сообщений>`",
                      inline=False)
    elif helpwho == 'утилиты':
        emb = discord.Embed(color=0xffaa00,
                            title="Доступные команды раздела `УТИЛИТЫ`:\n",
                            inline=False)
        emb.add_field(name=f"`{PREFIX}вычислить`",
                      value=f"Вычисляет значение из двух чисел\nПример: `{PREFIX}вычислить <1 число> <знак> <2 число>`",
                      inline=False)
        emb.add_field(name=f"`{PREFIX}рандом`",
                      value=f"Выбирает из двух чисел рандомное значение\nПример: `{PREFIX}рандлм <1 число> <2 число>`",
                      inline=False)
        emb.add_field(name=f"`{PREFIX}аватар`",
                      value=f"Показывает аватар пользователя\nПример: `{PREFIX}аватар [участник]`",
                      inline=False)
    elif helpwho == 'веселье':
        emb = discord.Embed(color=0xffaa00,
                            title="Доступные команды раздела `ВЕСЁЛОСТИ`:\n",
                            inline=False)
        emb.add_field(name=f"`{PREFIX}тест`",
                      value=f"Настоящий тест на беременность",
                      inline=False)
        emb.add_field(name=f"`{PREFIX}кубик`",
                      value=f"Брось игральный кубик",
                      inline=False)
        emb.add_field(
            name=f"`{PREFIX}бар`",
            value=f"Хочешь выпить? тогда тебе в <#845208669939040276>",
            inline=False)
    elif helpwho == 'инфо':
        emb = discord.Embed(color=0xffaa00,
                            title="Доступные команды раздела `ИНФОРМАЦИЯ`:\n",
                            inline=False)
        emb.add_field(name=f"`{PREFIX}помощь`",
                      value=f"Общая информация о командах\nПример: `{PREFIX}помощь [раздел]`",
                      inline=False)
        emb.add_field(name=f"`{PREFIX}юзер`",
                      value=f"Информация о участнике\nПример: `{PREFIX}юзер [участник]`",
                      inline=False)
        emb.add_field(name=f"`{PREFIX}сервер`",
                      value=f"Информация о сервере\nПример: `{PREFIX}сервер [id сервера]`",
                      inline=False)
    elif helpwho == 'embed':
        emb = discord.Embed(color=0xffaa00,
                            title="Доступные команды раздела `EMBED`:\n",
                            inline=False)
        emb.add_field(name=f"`{PREFIX}embed`",
                      value=f"Общая информация о командах\nПример: `{PREFIX}embed <Заглавие>|<текст>`",
                      inline=False)
        emb.add_field(name=f"`{PREFIX}embed_image`",
                      value=f"Информация о участнике\nПример: `{PREFIX}embed_image <Заглавие>|<текст>|<url изображения>`",
                      inline=False)
        emb.add_field(name=f"`{PREFIX}текст`",
                      value=f"Информация о сервере\nПример: `{PREFIX}текст <сообщение>`",
                      inline=False)
        emb.add_field(name=f"`{PREFIX}ответ`",
                      value=f"Информация о сервере\nПример: `{PREFIX}ответ <сообщение>`",
                      inline=False)
        emb.add_field(name=f"`{PREFIX}голосование`",
                      value=f"Информация о сервере\nПример: `{PREFIX}голосование <количество>  <Заглавие>|<сообщение>`",
                      inline=False)
        emb.add_field(name=f"`{PREFIX}опрос`",
                      value=f"Общая информация о командах\nПример: `{PREFIX}опрос <Заглавие>|<текст>`",
                      inline=False)
    emb.set_footer(text=f"Запросил: {ctx.author.name}",
                   icon_url=ctx.author.avatar_url)
    await ctx.send(embed=emb)


@bot.command()
async def сервер(ctx):
    server = ctx.guild
    print(server)
    name = str(server.name)
    description = str(server.description)

    owner = str(server.owner)
    id = str(server.id)
    region = str(server.region)
    memberCount = str(server.member_count)

    icon = str(server.icon_url)

    embed = discord.Embed(title='Информация о сервере ' + name,
                          description=f'Описание: {description}',
                          color=0xffaa00)
    embed.set_thumbnail(url=icon)
    embed.add_field(name="Создатель:", value=owner, inline=True)
    embed.add_field(name="Сервер ID:", value=id, inline=True)
    embed.add_field(name="Регион:", value=region, inline=True)
    embed.add_field(name="Количество участников:",
                    value=memberCount,
                    inline=True)

    await ctx.send(embed=embed)


@bot.command()
async def юзер(ctx, *, user: discord.Member = None):
    if user is None:
        user = ctx.author
    else:
        user = user
    date_format = "%a, %d %b %Y %I:%M %p"
    embed = discord.Embed(title='Информация о ' + user.name, color=0xffaa00)
    embed.set_thumbnail(url=user.avatar_url)
    embed.add_field(name="Имя", value=user, inline=False)
    embed.add_field(name="Присоединился",
                    value=user.joined_at.strftime(date_format),
                    inline=False)
    embed.add_field(name="Зарегистрировался: ",
                    value=user.created_at.strftime(date_format),
                    inline=False)
    if len(user.roles) > 1:
        role_string = ' '.join([r.mention for r in user.roles][1:])
        embed.add_field(name="Ролей: {}".format(len(user.roles) - 1),
                        value=role_string,
                        inline=False)
    embed.set_footer(text='ID: ' + str(user.id))
    return await ctx.send(embed=embed)


@bot.command()
async def бот(ctx):
    date_format = "%a, %d %b %Y %I:%M %p"
    embed = discord.Embed(title='Информация о ' + bot.name, color=0xffaa00)
    embed.set_thumbnail(url=bot.avatar_url)
    embed.add_field(name="Имя", value=bot.name, inline=False)
    embed.add_field(name="Присоединился",
                    value=bot.joined_at.strftime(date_format),
                    inline=False)
    embed.add_field(name="Зарегистрировался: ",
                    value=bot.created_at.strftime(date_format),
                    inline=False)
    embed.set_footer(text='ID: ' + str(bot.id))
    return await ctx.send(embed=embed)


@bot.command()
async def бар(ctx, *, buy=None):
    if ctx.channel.id == 845208669939040276:
        if buy is None:
            emb = discord.Embed(color=0xffaa00, title="🍺 БАР 🍺")
            emb.add_field(
                name=f"`{PREFIX}список`",
                value=f"Список напиток (подробнее `{PREFIX}бар список`)")
        elif buy == 'список':
            emb = discord.Embed(color=0xffaa00, title="🍺 СПИСОК НАПИТОК 🍺")
            emb.add_field(
                name=f"<:baltika9:856192257987051560> Балтика 9 <:baltika9:856192257987051560>",
                value=
                f"Чтобы купить Балтику 9 надо написать `{PREFIX}купить 1` или `{PREFIX}купить балтика 9`",
                inline=False)
            emb.add_field(
                name=f"<:cum:856191650593112095> Стакан CUM'a <:cum:856191650593112095>",
                value=
                f"Чтобы купить стакан CUM'a надо написать `{PREFIX}купить 2` или `{PREFIX}купить стакан CUM'a`",
                inline=False)
        await ctx.send(embed=emb)


@bot.command()
async def купить(ctx, *, name: str):
    if ctx.channel.id == 845208669939040276:
        if name == "балтика 9" or name == "1":
            emb = discord.Embed(color=0xffaa00, title="🍺 БАР 🍺")
            emb.add_field(name=f"Вы купили Балтику 9 <:baltika9:856192257987051560>",
                          value="Пейте на здоровье")
        elif name == "стакан CUM'a" or name == "2":
            emb = discord.Embed(color=0xffaa00, title="🍺 БАР 🍺")
            emb.add_field(name=f"Вы купили стакан CUM'a <:cum:856191650593112095>",
                          value="Пейте на здоровье")
        await ctx.send(embed=emb)


#=======ADMIN========#
@commands.has_any_role(789459282956910603, 787752485942067242)
@bot.command()
async def бан(ctx, member: discord.Member, *, reason=None):
    if reason == None:
          emb = discord.Embed(
            color=discord.Color.red(),
            description=f":white_check_mark: Участник {member.name} был забанен")
    else:
          emb = discord.Embed(
            color=discord.Color.red(),
            description=f":white_check_mark: Участник {member.name} был забанен по причине {reason}")
    await member.ban(reason=reason)
    emb.set_footer(text=f"Запросил: {ctx.author.name}",
                   icon_url=ctx.author.avatar_url)
    await ctx.send(embed=emb)
    await ctx.message.add_reaction("✅")


@commands.has_any_role(789459282956910603, 787752485942067242)
@bot.command()
async def кик(ctx, member: discord.Member, *, reason=None):
    if reason == None:
          emb = discord.Embed(
            color=discord.Color.orange(),
            description=f":white_check_mark: Участник {member.name} был кикнут")
    else:
          emb = discord.Embed(
            color=discord.Color.orange(),
            description=f":white_check_mark: Участник {member.name} был кикнут по причине {reason}")
    await member.kick(reason=reason)
    emb.set_footer(text=f"Запросил: {ctx.author.name}",
                   icon_url=ctx.author.avatar_url)
    await ctx.send(embed=emb)
    await ctx.message.add_reaction("✅")


@commands.has_any_role(789459282956910603, 787752485942067242)
@bot.command()
async def разбан(ctx, *, member : str):
    banned_users = await ctx.guild.bans()
    member_name, member_discriminator = member.split('#')
    for ban_entry in banned_users:
        user = ban_entry.user
        if (user.name, user.discriminator) == (member_name,
                                               member_discriminator):
            await ctx.guild.unban(user)
            return
    emb = discord.Embed(
    color=discord.Color.green(),
    description=f":white_check_mark: Участник {member.name} был разбанен")
    await ctx.send(embed = emb)
    await ctx.message.add_reaction("✅")


@bot.command()
@commands.has_any_role(789459282956910603, 825073861011439697,
                       787752485942067242)
@commands.has_permissions(manage_roles=True)
async def мут(ctx, user: discord.Member, time: int, reason=None):
    role = discord.utils.get(ctx.message.guild.roles, id=797512756407435264)
    if reason == None:
        emb = discord.Embed(
            color=0xffaa00,
            description=f":white_check_mark: Участник {user.name} получил мут на {time} мин"
        )
    else:
        emb = discord.Embed(
            color=0xffaa00,
            description=
            f":white_check_mark: Участник {user.name} получил мут на {time} минут по причине: {reason}"
        )
    emb.set_footer(text=f"Запросил: {ctx.author.name}",
                   icon_url=ctx.author.avatar_url)
    await ctx.send(embed=emb)
    await user.add_roles(role)
    await user.move_to(None)
    await asyncio.sleep(time * 60)
    if get(user.roles, id=797512756407435264):
        await user.remove_roles(role)
        emb = discord.Embed(
            color=0xffaa00,
            description=
            f":white_check_mark: С участника {user.name} снят мут"
        )
    await ctx.send(embed=emb)
    await ctx.message.add_reaction("✅")


@bot.command()
@commands.has_any_role(789459282956910603, 825073861011439697,
                       787752485942067242)
@commands.has_permissions(manage_roles=True)
async def размут(ctx, user: discord.Member):
    role = discord.utils.get(ctx.message.guild.roles, id=797512756407435264)
    emb = discord.Embed(color=discord.Color.green(),
                        description=f":white_check_mark: Участник {user.name} был размутен")
    emb.set_footer(text=f"Запросил: {ctx.author.name}",
                   icon_url=ctx.author.avatar_url)
    await ctx.send(embed=emb)
    await user.remove_roles(role)
    await ctx.message.add_reaction("✅")


@bot.command()
@commands.has_any_role(789459282956910603, 825073861011439697,
                       787752485942067242)
async def очистить(ctx, amount=999):
    await ctx.channel.purge(limit=amount)
    emb = discord.Embed(
        color=0xffaa00,
        description=':white_check_mark:  Было очищено: {0}'.format(amount))
    await ctx.send(embed=emb)


@commands.has_permissions(administrator=True)
@bot.command()
async def embed(ctx, role, *, agrs: str):
    await ctx.channel.purge(limit=1)
    agrs = agrs.split('|')
    emb = discord.Embed(title=agrs[0], color=0xffaa00, description=agrs[1])
    if role != None:
        await ctx.send(role, embed=emb)
    else:
        await ctx.send(embed=emb)


@commands.has_permissions(administrator=True)
@bot.command()
async def embed_image(ctx, role, *, agrs: str):
    await ctx.channel.purge(limit=1)
    agrs = agrs.split('|')
    emb = discord.Embed(title=agrs[0], color=0xffaa00, description=agrs[1])
    emb.set_image(url=agrs[2])
    if role != None:
        await ctx.send(role, embed=emb)
    else:
        await ctx.send(embed=emb)


@commands.has_permissions(administrator=True)
@bot.command()
async def ответить(ctx, idm, *, agrs: str):
    await ctx.channel.purge(limit=1)
    msg = await ctx.fetch_message(idm)
    await msg.reply(agrs)


@commands.has_permissions(administrator=True)
@bot.command()
async def текст(ctx, *, agrs: str):
    await ctx.channel.purge(limit=1)
    await ctx.send(agrs)


@bot.command()
async def тест(ctx):
    rand = random.randint(0, 1)
    if rand == 0:
        emb = discord.Embed(color=0xffaa00,
                            description='🙈 **Вы не беременны**')
    else:
        emb = discord.Embed(color=0xffaa00, description='🙊 **Вы беременны!**')
    await ctx.send(embed=emb)


@commands.has_any_role(789459282956910603, 825073861011439697,
                       787752485942067242)
@bot.command()
async def пред(ctx, member: discord.Member, *, about: str):
    if get(member.roles, name="МУТ"):
        emb = discord.Embed(
            color=discord.Color.red(),
            description=
            f':x: У участника **{member.name}** уже есть предупреждение')
        emb.set_footer(text=f"Запросил: {ctx.author.name}",
                       icon_url=ctx.author.avatar_url)
        await ctx.send(embed=embed)
    else:
        role = discord.utils.get(ctx.message.guild.roles, name='МУТ')
        emb = discord.Embed(
            color=0xffaa00,
            description=
            f':warning: Участник **{member.name}** получил предупреждение от **{ctx.message.author.name}** по причине: **{about}**'
        )
        emb.set_footer(text=f"Запросил: {ctx.author.name}",
                       icon_url=ctx.author.avatar_url)
        await ctx.send(embed=emb)
        await member.add_roles(role)
        await member.move_to(None)
        await asyncio.sleep(10 * 60)
        await member.remove_roles(role)
        await ctx.message.add_reaction("✅")


@commands.has_any_role(789459282956910603, 825073861011439697,
                       787752485942067242)
@bot.command()
async def снятьпред(ctx, member: discord.Member):
    if get(member.roles, name="МУТ"):
        role = discord.utils.get(ctx.message.guild.roles, name='МУТ')
        emb = discord.Embed(
            color=0xffaa00,
            description=
            f':white_check_mark: С **{member.name}** было снято предупреждение'
        )
        emb.set_footer(text=f"Запросил: {ctx.author.name}",
                       icon_url=ctx.author.avatar_url)
        await ctx.send(embed=emb)
        await member.remove_roles(role)
    else:
        emb = discord.Embed(
            color=discord.Color.red(),
            description=
            f':x: У участника **{member.name}** нет никаких предупреждений')
        emb.set_footer(text=f"Запросил: {ctx.author.name}",
                       icon_url=ctx.author.avatar_url)
        await ctx.send(embed=emb)


@bot.command()
@commands.has_any_role(789459282956910603, 825073861011439697,
                       787752485942067242)
@commands.has_permissions(manage_roles=True)
async def времроль(ctx, member: discord.Member, role: discord.Role, time: int):
    emb = discord.Embed(
        color=0xffaa00,
        description=
        f":white_check_mark: Участнику **{ member.name }** была выдана роль { role } на **{ time }**"
    )
    emb.set_footer(text=f"Запросил: {ctx.author.name}",
                   icon_url=ctx.author.avatar_url)
    await ctx.send(embed=emb)
    await member.add_roles(role)
    await member.move_to(None)
    await asyncio.sleep(time * 60)
    await member.remove_roles(role)


#========UTILS========#

emoji = ['1️⃣', '2️⃣', '3️⃣', '4️⃣', '5️⃣', '6️⃣', '7️⃣', '8️⃣', '9️⃣', '🔟']


@bot.command()
@commands.has_permissions(administrator=True)
async def голосование(ctx, count: int, *, text: str):
    await ctx.channel.purge(limit=1)
    emb = discord.Embed(color=0xffaa00,
                        title=":loudspeaker: Голосование :loudspeaker:",
                        description=text,
                        reason=True)
    s = await ctx.send(embed=emb)
    for i in range(count):
        await s.add_reaction(emoji[i])


@bot.command()
@commands.has_permissions(administrator=True)
async def опрос(ctx, *, text: str):
    await ctx.channel.purge(limit=1)
    emb = discord.Embed(color=0xffaa00,
                        title=":loudspeaker: Опрос :loudspeaker:",
                        description=text)
    s = await ctx.send(embed=emb)
    await s.add_reaction("✅")
    await s.add_reaction("❌")


@bot.command()
async def кубик(ctx):
    rand = random.randint(0, 6)
    if rand != 6:
        emb = discord.Embed(color=0xffaa00,
                            description=f':game_die: Тебе выпало {rand + 1}!')
    else:
        emb = discord.Embed(color=0xffaa00,
                            description=f':game_die: Тебе выпало {rand}!')
    print(rand)
    await ctx.send(embed=emb)

@bot.command()
async def вычислить(ctx, a: float, znak: str, b: float):
    if znak == "+":
        emb = discord.Embed(
            description=f":white_check_mark: Ответ: {int(a + b)}",
            color=0xffaa00)
    elif znak == "-":
        emb = discord.Embed(description=f":white_check_mark: Ответ: {a - b}",
                            color=0xffaa00)
    elif znak == "/":
        emb = discord.Embed(description=f":white_check_mark: Ответ: {a / b}",
                            color=0xffaa00)
    elif znak == "*":
        emb = discord.Embed(description=f":white_check_mark: Ответ: {a * b}",
                            color=0xffaa00)
    await ctx.send(embed=emb)


@bot.command()
async def рандом(ctx, a: float, b: float):
    await ctx.send(embed=discord.Embed(
        description=":white_check_mark: Рандомное число: {0}".format(
            random.randint(a, b)),
        color=0xffaa00))

@bot.command()
async def аватар(ctx, *, user: discord.Member = None):
  if user is None:
        user = ctx.author
  emb = discord.Embed(title=f'Аватар {user.name}:', color=0xffaa00)
  emb.set_image(url=user.avatar_url)
  await ctx.send(embed = emb)


@bot.event
async def on_message(message):
    await bot.process_commands(message)
    oklist = ['ok', 'okey', 'Ok', 'Okey', 'ок', 'окей', 'Ок', 'Окей']
    for i in oklist:
        if i in message.content:
            await message.add_reaction('🆗')
    if 'префикс' in message.content:
        await message.channel.send(f'Перфикс бота: "**{PREFIX}**"')


@bot.event
@commands.has_permissions(manage_roles=True)
async def on_member_join(member):
    channel = bot.get_channel(789459962241482783)
    role = discord.utils.get(member.guild.roles, id=789455799507484723)
    await member.add_roles(role)
    emb = discord.Embed(color=0xffaa00,
                        title=f"👋 Привет { member.name }",
                        description="Рад тебя видеть на моём Discord сервере!",
                        reason=True)
    await channel.send(embed=emb)


@bot.event
async def on_member_remove(member):
    channel = bot.get_channel(789459962241482783)
    emb = discord.Embed(color=0xffaa00,
                        title=f"😔 Прощай { member.name }",
                        description="Надеюсь, ты ещё вернёшься к нам",
                        reason=True)
    await channel.send(embed=emb)


token = "ODAwMjk0NjUyMDI0MDYxOTYz.YAQCeQ.CzDW5II8KkzB0ddX9piuZpbr-VM"
bot.run(token)