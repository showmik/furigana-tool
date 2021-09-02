# Furigana Tool
**Furigana Tool** automates the process of writing HTML code for Furigana in *[ruby](https://developer.mozilla.org/en-US/docs/Web/HTML/Element/ruby)* syntax. It uses a modified version of the **[Gem](https://github.com/helephant/Gem)** library and adds a User Interface to it.

This tool was intended to be used along with the **[HTML Table Generator](https://github.com/showmik/html-table-generator)** for one of my projects.

## The Ruby Syntax

> "A ruby annotation is a small extra text, attached to the main text to indicate the pronunciation or meaning of the corresponding characters. This kind of annotation is often used in Japanese publications." — W3Schools

For example, let's consider the word *Furigana*:

<img src="Docs/Fu_ri_ga_na_Furigana_Example.png" width="200" alt="Furigana"/>

To create something like this in HTML, we can write:

```
<ruby><rb>振</rb><rt>ふ</rt><rb>り</rb><rt></rt><rb>仮</rb><rt>が</rt><rb>名</rb><rt>な</rt></ruby>
```

And the result would be this:

> <ruby><rb>振</rb><rt>ふ</rt><rb>り</rb><rt></rt><rb>仮</rb><rt>が</rt><rb>名</rb><rt>な</rt></ruby>

<br/>

Or the word *Dai ni kan (Volume 2)*:

<img src="Docs/Dai_ni_can_Furigana_Example.png" width="200" alt="DaiNiKan"/>

HTML:
```
<ruby><rb>第</rb><rt>たい</rt><rb>2</rb><rt></rt><rb>巻</rb><rt>かん</rt></ruby>
```
Resul:
> <ruby><rb>第</rb><rt>たい</rt><rb>2</rb><rt></rt><rb>巻</rb><rt>かん</rt></ruby>

## Using the Furigana Tool

As you can see, it can be very tedious to write code using ruby syntax every time I want to use Furigana. This tool makes it a lot easier. I just need to input Kanji and Furigana, and it will generate the code for me.


