using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaihonSample
{
    public class LineData
    {
        public String VoiceNo;      // ボイスNo
        public String Character;    // キャラクター名
        public String Voice;        // 台詞

        public float StartX;        // 描画開始位置
        public float EndX;          // 描画終了位置

        public LineData()
        {
            VoiceNo = "";
            Character = "";
            Voice = "";

            StartX = 0;
            EndX = 0;
        }

        public static List<LineData> CreateTestData()
        {

            var list = new List<LineData>();

            list.Add(new LineData()
            {
                VoiceNo = "OTO_S2_Ev34_001",
                Character = "【音也】",
                Voice = "レンはよく一人旅とかロケで海外旅行に\r\n" +
                "行ってるよね。いつもお土産くれるし！\n\r" +
                "思い出に残ってるところはある？"
            });

            list.Add(new LineData()
            {
                VoiceNo = "REN_S2_Ev34_001",
                Character = "【レン】",
                Voice = "どの国も楽しかったし、印象に残ってるよ。\r\n" +
                            "写真を撮ってあるから、よかったら見るかい？\r\n" +
                            "ほら、これとか……"
            });

            list.Add(new LineData()
            {
                VoiceNo = "OTO_S2_Ev34_002",
                Character = "【音也】",
                Voice = "わあ！　レンの写真、どれもすごく綺麗だね。\r\n" +
                            "飛行機はちょっと苦手だけど、\r\n" +
                            "いろんなところに行ってみたくなる！"
            });

            list.Add(new LineData()
            {
                VoiceNo = "REN_S2_Ev34_002",
                Character = "【レン】",
                Voice = "そう言ってもらえて嬉しいよ。\r\n" +
                            "地図を持たない、自由気ままな旅……。\r\n" +
                            "迷子になることもあるけど、それもまた楽しいんだ。"
            });

            list.Add(new LineData()
            {
                VoiceNo = "REN_S2_Ev34_003",
                Character = "【レン】",
                Voice = "思い出話ならたくさんあるよ。\r\n" +
                            "どんな話がいいかな？"
            });

            list.Add(new LineData()
            {
                VoiceNo = "",
                Character = "",
                Voice = "■２章　：　\r\n" +
                            "背景：南欧風の建物の前\r\n" +
                            "レン衣装：カード衣装\r\n" +
                            "シナリオ（５ｗ）"
            });

            list.Add(new LineData()
            {
                VoiceNo = "REN_S2_Ev34_004",
                Character = "【レン】",
                Voice = "旅行雑誌でスペインを特集するから、\r\n" +
                            "グラビアをオレたちに……って依頼を聞いたときは、\r\n" +
                            "心が震えたよ。"
            });

            list.Add(new LineData()
            {
                VoiceNo = "REN_S2_Ev34_005",
                Character = "【レン】",
                Voice = "あの素晴らしい国のイメージで、\r\n" +
                            "イッキとオレを選んでもらえたってことだからね。\r\n" +
                            "その想いに全力で応えたいって思った。"
            });

            list.Add(new LineData()
            {
                VoiceNo = "REN_S2_Ev34_006",
                Character = "【レン】",
                Voice = "モデルとして要求に応じるのは当然のことだけど、\r\n" +
                            "それ以上の熱を感じてほしい。とっておきのポーズをレディに\r\n" +
                            "見てもらえるように、研究しなくちゃね。"
            });

            list.Add(new LineData()
            {
                VoiceNo = "REN_S2_Ev34_007",
                Character = "【レン】",
                Voice = "オレたちが着るのはマタドールの衣装。\r\n" +
                            "だけど闘牛以外にも見どころにあふれた情熱の国。\r\n" +
                            "また旅行したくなるな。"
            });

            list.Add(new LineData()
            {
                VoiceNo = "REN_S2_Ev34_008",
                Character = "【レン】",
                Voice = "グラビアを見たレディにも、オレと一緒に\r\n" +
                            "旅行したい……そう思ってもらえるような、\r\n" +
                            "最高のショットにしよう。"
            });

            list.Add(new LineData()
            {
                VoiceNo = "",
                Character = "",
                Voice = "■３章　　　　：　撮影風景\r\n" +
                            "背景　　　　　　：野外闘牛場\r\n" +
                            "レン衣装　　：カード衣装　\r\n" +
                            "シナリオ（５ｗ）"
            });

            list.Add(new LineData()
            {
                VoiceNo = "REN_S2_Ev34_009",
                Character = "【レン】",
                Voice = "（赤い布を舞うように広げたポーズがいいかな。\r\n" +
                            "闘いを前にして、美しく華やかに見えるように。\r\n" +
                            "こんな感じで……）\r\n"
            });

            list.Add(new LineData()
            {
                VoiceNo = "",
                Character = "",
                Voice = "／／ＳＥ：布を広げる音（ばさっ）\r\n" +
                            "／／☆シャッター音"
            });

            list.Add(new LineData()
            {
                VoiceNo = "REN_S2_Ev34_010",
                Character = "【レン】",
                Voice = "（さっき見せてくれた、\r\n" +
                            "イッキのダイナミックな動きも刺激的だったな。\r\n" +
                            "もっと動きを大きくしてみよう）"
            });

            list.Add(new LineData()
            {
                VoiceNo = "REN_S2_Ev34_011",
                Character = "【レン】",
                Voice = "（剣を片手に持って、布を翻すポーズもいい。\r\n" +
                            "目の前に闘牛がいるイメージで、真剣に。\r\n" +
                            "どうかな？）"
            });

            list.Add(new LineData()
            {
                VoiceNo = "",
                Character = "",
                Voice = "／／☆シャッター音"
            });

            list.Add(new LineData()
            {
                VoiceNo = "REN_S2_Ev34_012",
                Character = "【レン】",
                Voice = "（それに、レディを誘う視線も加えたい。\r\n" +
                            "……うん、いいね。燃えてきた）"
            });

            list.Add(new LineData()
            {
                VoiceNo = "",
                Character = "",
                Voice = "／／☆シャッター音"
            });

            list.Add(new LineData()
            {
                VoiceNo = "REN_S2_Ev34_013",
                Character = "【レン】",
                Voice = "（ふふっ。\r\n" +
                            "レディたちのハートに火を灯せるような、\r\n" +
                            "情熱的なマタドールになれたかな？）"
            });

            list.Add(new LineData()
            {
                VoiceNo = "",
                Character = "",
                Voice = "■サイドストーリーＳＲ音也\r\n" +
                            "■１章　　　　：　気になるところ\r\n" +
                            "背景　　　　　　：事務所　\r\n" +
                            "音也衣装　　：長袖私服\r\n" +
                            "シナリオ（５ｗ）"
            });

            list.Add(new LineData()
            {
                VoiceNo = "OTO_S2_Ev34_003",
                Character = "【音也】",
                Voice = "旅行雑誌のグラビアっていっても、\r\n" +
                            "レンに頼ってばっかりじゃダメだよね。\r\n" +
                            "俺も自分なりに調べなきゃ！"
            });

            list.Add(new LineData()
            {
                VoiceNo = "OTO_S2_Ev34_004",
                Character = "【音也】",
                Voice = "まずはー……スペインといえば、\r\n" +
                            "やっぱサッカーかな！　攻めの姿勢かぁ。\r\n" +
                            "これ、撮影でも活かせるかも！"
            });

            list.Add(new LineData()
            {
                VoiceNo = "OTO_S2_Ev34_005",
                Character = "【音也】",
                Voice = "観光スポットもたくさんあって、お祭りも……\r\n" +
                            "わっ、大きな海老がどーんって乗ってる。\r\n" +
                            "このパエリア美味しそう！"
            });

            list.Add(new LineData()
            {
                VoiceNo = "OTO_S2_Ev34_006",
                Character = "【音也】",
                Voice = "写真のこれ、何人前だろ？\r\n" +
                            "ＳＴ☆ＲＩＳＨのみんなでワイワイしながら\r\n" +
                            "食べたいな。"
            });

            list.Add(new LineData()
            {
                VoiceNo = "OTO_S2_Ev34_007",
                Character = "【音也】",
                Voice = "調べれば調べるほど、行きたくなるところだなぁ。\r\n" +
                            "俺のグラビアでそう感じてもらえるように、\r\n" +
                            "マタドール、しっかり務めよう！"
            });

            list.Add(new LineData()
            {
                VoiceNo = "",
                Character = "",
                Voice = "■２章　　　　：撮影スタジオ\r\n" +
                            "背景　　　　　　：野外闘牛場\r\n" +
                            "音也衣装　　：カード衣装　\r\n" +
                            "シナリオ（５ｗ）"
            });

            list.Add(new LineData()
            {
                VoiceNo = "",
                Character = "",
                Voice = "／／ＳＥ：布を広げる音（ばさっ）"
            });

            list.Add(new LineData()
            {
                VoiceNo = "OTO_S2_Ev34_008",
                Character = "【音也】",
                Voice = "（よっと、綺麗に広がったかな？\r\n" +
                            "もっと大きく振ってみよう。\r\n" +
                            "それっ！）"
            });

            list.Add(new LineData()
            {
                VoiceNo = "",
                Character = "",
                Voice = "／／ＳＥ：布を広げる音（ばさっ）"
            });

            list.Add(new LineData()
            {
                VoiceNo = "OTO_S2_Ev34_009",
                Character = "【音也】",
                Voice = "（うん、今のいい感じ！\r\n" +
                            "じゃあ次は、もっと踏み込んで\r\n" +
                            "ギリギリを攻めてみよう）"
            });

            list.Add(new LineData()
            {
                VoiceNo = "",
                Character = "",
                Voice = "／／ＳＥ：足音"
            });

            list.Add(new LineData()
            {
                VoiceNo = "OTO_S2_Ev34_010",
                Character = "【音也】",
                Voice = "（目の前に闘牛がいるイメージで、\r\n" +
                            "今度は真剣な表情に……）"
            });

            list.Add(new LineData()
            {
                VoiceNo = "OTO_S2_Ev34_011",
                Character = "【音也】",
                Voice = "（楽しくなってきた！\r\n" +
                            "もっと大きく動いてみてもいいかも。\r\n" +
                            "そう、こんな風に！）"
            });

            list.Add(new LineData()
            {
                VoiceNo = "",
                Character = "",
                Voice = "／／ＳＥ：布が翻る音"
            });

            list.Add(new LineData()
            {
                VoiceNo = "OTO_S2_Ev34_012",
                Character = "【音也】",
                Voice = "（サイッコー！\r\n" +
                            "みんなにも、この情熱が届きますように！！）"
            });

            list.Add(new LineData()
            {
                VoiceNo = "",
                Character = "",
                Voice = "／／ＥＮＤ"
            });

            return list;
        }

    }

}
