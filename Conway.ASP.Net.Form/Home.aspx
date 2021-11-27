<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Conway.ASP.Net.Form.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 
    <title></title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
    <script rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <script type="text/javascript" src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript">
        $(document).ready(function () {
            //
            // Client Side Search (Autocomplete)
            // Get the search Key from the TextBox
            // Iterate through the 1st Column.
            // td:nth-child(1) - Filters only the 1st Column
            // If there is a match show the row [$(this).parent() gives the Row]
            // Else hide the row [$(this).parent() gives the Row]
            $('#txtID').keyup(function (event) {
                var searchKey = $(this).val().toLowerCase();
                $("#data_Product tr td:nth-child(2)").each(function () {
                    var cellText = $(this).text().toLowerCase();
                    if (cellText.indexOf(searchKey) >= 0) {
                        $(this).parent().show();
                    }
                    else {
                        $(this).parent().hide();
                    }
                });
            });
        });
    </script>   
    <link rel="stylesheet" href="~/CSS/Home2.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="rows">
            <div class="row1">
                <div class="meubel-links">
                    <asp:Panel runat="server" class="boven" ID="clm_81" aria-orientation="vertical">
                        <asp:Label runat="server" ID="lbl_81_Prix" class="textVerticalLinkseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_81" class="textVerticalLinks"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_82">
                        <asp:Label runat="server" ID="lbl_82_Prix" class="textVerticalLinkseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_82" class="textVerticalLinks"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_83">
                        <asp:Label runat="server" ID="lbl_83_Prix" class="textVerticalLinkseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_83" class="textVerticalLinks"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_84">
                        <asp:Label runat="server" ID="lbl_84_Prix" class="textVerticalLinkseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_84" class="textVerticalLinks"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_85">
                        <asp:Label runat="server" ID="lbl_85_Prix" class="textVerticalLinkseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_85" class="textVerticalLinks"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_86">
                        <asp:Label runat="server" ID="lbl_86_Prix" class="textVerticalLinkseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_86" class="textVerticalLinks"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_87">
                        <asp:Label runat="server" ID="lbl_87_Prix" class="textVerticalLinkseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_87" class="textVerticalLinks"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_88">
                        <asp:Label runat="server" ID="lbl_88_Prix" class="textVerticalLinkseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_88" class="textVerticalLinks"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_89">
                        <asp:Label runat="server" ID="lbl_89_Prix" class="textVerticalLinkseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_89" class="textVerticalLinks"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_90">
                        <asp:Label runat="server" ID="lbl_Breedte_Links" class="textBreedteLinks"></asp:Label>
                        <asp:Label runat="server" ID="lbl_90_Prix" class="textVerticalLinkseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_90" class="textVerticalLinks"></asp:Label></asp:Panel>

                    <div class="beneden">81</div>
                    <div class="beneden">82</div>
                    <div class="beneden">83</div>
                    <div class="beneden">84</div>
                    <div class="beneden">85</div>
                    <div class="beneden">86</div>
                    <div class="beneden">87</div>
                    <div class="beneden">88</div>
                    <div class="beneden">89</div>
                    <div class="beneden">90</div>
                </div>

                <div class="meubel-midden">
                    <asp:Panel runat="server" class="boven" ID="clm_61">
                        <asp:Label runat="server" ID="lbl_61_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_61" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_62">
                        <asp:Label runat="server" ID="lbl_62_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_62" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_63">
                        <asp:Label runat="server" ID="lbl_63_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_63" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_64">
                        <asp:Label runat="server" ID="lbl_64_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_64" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_65">
                        <asp:Label runat="server" ID="lbl_65_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_65" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_66">
                        <asp:Label runat="server" ID="lbl_66_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_66" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_67">
                        <asp:Label runat="server" ID="lbl_67_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_67" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_68">
                        <asp:Label runat="server" ID="lbl_68_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_68" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_69">
                        <asp:Label runat="server" ID="lbl_69_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_69" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_70">
                        <asp:Label runat="server" ID="lbl_70_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_70" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_71" >
                        <asp:Label runat="server" ID="lbl_71_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_71" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_72">
                        <asp:Label runat="server" ID="lbl_72_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_72" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_73">
                        <asp:Label runat="server" ID="lbl_73_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_73" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_74" >
                        <asp:Label runat="server" ID="lbl_74_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_74" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_75">
                        <asp:Label runat="server" ID="lbl_75_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_75" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_76" >
                        <asp:Label runat="server" ID="lbl_76_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_76" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_77" >
                        <asp:Label runat="server" ID="lbl_77_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_77" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_78" >
                        <asp:Label runat="server" ID="lbl_78_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_78" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_79" >
                        <asp:Label runat="server" ID="lbl_79_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_79" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_80" >
                        <asp:Label runat="server" ID="lbl_Breedte_Midden_Boven" class="textBreedteMiddenBoven"></asp:Label>
                        <asp:Label runat="server" ID="lbl_80_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_80" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>

                    <div class="beneden">61</div>
                    <div class="beneden">62</div>
                    <div class="beneden">63</div>
                    <div class="beneden">64</div>
                    <div class="beneden">65</div>
                    <div class="beneden">66</div>
                    <div class="beneden">67</div>
                    <div class="beneden">68</div>
                    <div class="beneden">69</div>
                    <div class="beneden">70</div>
                    <div class="beneden">71</div>
                    <div class="beneden">72</div>
                    <div class="beneden">73</div>
                    <div class="beneden">74</div>
                    <div class="beneden">75</div>
                    <div class="beneden">76</div>
                    <div class="beneden">77</div>
                    <div class="beneden">78</div>
                    <div class="beneden">79</div>
                    <div class="beneden">80</div>

                    <asp:Panel runat="server" class="boven" ID="clm_41">
                        <asp:Label runat="server" ID="lbl_41_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_41" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_42">
                        <asp:Label runat="server" ID="lbl_42_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_42" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_43">
                        <asp:Label runat="server" ID="lbl_43_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_43" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_44">
                        <asp:Label runat="server" ID="lbl_44_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_44" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_45">
                        <asp:Label runat="server" ID="lbl_45_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_45" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_46">
                        <asp:Label runat="server" ID="lbl_46_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_46" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_47">
                        <asp:Label runat="server" ID="lbl_47_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_47" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_48">
                        <asp:Label runat="server" ID="lbl_48_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_48" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_49" >
                        <asp:Label runat="server" ID="lbl_49_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_49" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_50">
                        <asp:Label runat="server" ID="lbl_50_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_50" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_51">
                        <asp:Label runat="server" ID="lbl_51_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_51" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_52">
                        <asp:Label runat="server" ID="lbl_52_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_52" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_53">
                        <asp:Label runat="server" ID="lbl_53_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_53" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_54">
                        <asp:Label runat="server" ID="lbl_54_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_54" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_55">
                        <asp:Label runat="server" ID="lbl_55_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_55" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_56">
                        <asp:Label runat="server" ID="lbl_56_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_56" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_57">
                        <asp:Label runat="server" ID="lbl_57_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_57" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_58">
                        <asp:Label runat="server" ID="lbl_58_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_58" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_59">
                        <asp:Label runat="server" ID="lbl_59_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_59" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_60">
                        <asp:Label runat="server" ID="lbl_Breedte_Midden_Midden" class="textBreedteMiddenMidden"></asp:Label>
                        <asp:Label runat="server" ID="lbl_60_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_60" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>

                    <div class="beneden">41</div>
                    <div class="beneden">42</div>
                    <div class="beneden">43</div>
                    <div class="beneden">44</div>
                    <div class="beneden">45</div>
                    <div class="beneden">46</div>
                    <div class="beneden">47</div>
                    <div class="beneden">48</div>
                    <div class="beneden">49</div>
                    <div class="beneden">50</div>
                    <div class="beneden">51</div>
                    <div class="beneden">52</div>
                    <div class="beneden">53</div>
                    <div class="beneden">54</div>
                    <div class="beneden">55</div>
                    <div class="beneden">56</div>
                    <div class="beneden">57</div>
                    <div class="beneden">58</div>
                    <div class="beneden">59</div>
                    <div class="beneden">60</div>

                    <asp:Panel runat="server" class="boven" ID="clm_21">
                        <asp:Label runat="server" ID="lbl_21_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_21" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_22">
                        <asp:Label runat="server" ID="lbl_22_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_22" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_23">
                        <asp:Label runat="server" ID="lbl_23_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_23" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_24">
                        <asp:Label runat="server" ID="lbl_24_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_24" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_25">
                        <asp:Label runat="server" ID="lbl_25_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_25" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_26">
                        <asp:Label runat="server" ID="lbl_26_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_26" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_27">
                        <asp:Label runat="server" ID="lbl_27_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_27" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_28">
                        <asp:Label runat="server" ID="lbl_28_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_28" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_29">
                        <asp:Label runat="server" ID="lbl_29_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_29" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_30">
                        <asp:Label runat="server" ID="lbl_30_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_30" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_31">
                        <asp:Label runat="server" ID="lbl_31_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_31" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_32">
                        <asp:Label runat="server" ID="lbl_32_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_32" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_33">
                        <asp:Label runat="server" ID="lbl_33_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_33" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_34">
                        <asp:Label runat="server" ID="lbl_34_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_34" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_35">
                        <asp:Label runat="server" ID="lbl_35_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_35" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_36" >
                        <asp:Label runat="server" ID="lbl_36_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_36" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_37" >
                        <asp:Label runat="server" ID="lbl_37_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_37" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_38">
                        <asp:Label runat="server" ID="lbl_38_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_38" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_39">
                        <asp:Label runat="server" ID="lbl_39_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_39" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_40">
                        <asp:Label runat="server" ID="lbl_Breedte_Midden_Beneden" class="textBreedteMiddenBeneden"></asp:Label>
                        <asp:Label runat="server" ID="lbl_40_Prix" class="textVerticalMiddenBoveneuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_40" class="textVerticalMiddenBoven"></asp:Label></asp:Panel>

                    <div class="beneden">21</div>
                    <div class="beneden">22</div>
                    <div class="beneden">23</div>
                    <div class="beneden">24</div>
                    <div class="beneden">25</div>
                    <div class="beneden">26</div>
                    <div class="beneden">27</div>
                    <div class="beneden">28</div>
                    <div class="beneden">29</div>
                    <div class="beneden">30</div>
                    <div class="beneden">31</div>
                    <div class="beneden">32</div>
                    <div class="beneden">33</div>
                    <div class="beneden">34</div>
                    <div class="beneden">35</div>
                    <div class="beneden">36</div>
                    <div class="beneden">37</div>
                    <div class="beneden">38</div>
                    <div class="beneden">39</div>
                    <div class="beneden">40</div>
                </div>

                <div class="meubel-rechts">
                    <asp:Panel runat="server" class="boven" ID="clm_11">
                        <asp:Label runat="server" ID="lbl_11_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_11" class="textVerticalRechts"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_12">
                        <asp:Label runat="server" ID="lbl_12_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_12" class="textVerticalRechts"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_13">
                        <asp:Label runat="server" ID="lbl_13_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_13" class="textVerticalRechts"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_14">
                        <asp:Label runat="server" ID="lbl_14_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_14" class="textVerticalRechts"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_15">
                        <asp:Label runat="server" ID="lbl_15_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_15" class="textVerticalRechts"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_16">
                        <asp:Label runat="server" ID="lbl_16_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_16" class="textVerticalRechts"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_17">
                        <asp:Label runat="server" ID="lbl_17_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_17" class="textVerticalRechts"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_18">
                        <asp:Label runat="server" ID="lbl_18_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_18" class="textVerticalRechts"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_19">
                        <asp:Label runat="server" ID="lbl_19_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_19" class="textVerticalRechts"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_20">
                        <asp:Label runat="server" ID="lbl_Breedte_Rechts_Boven" class="textBreedteRechtBoven"></asp:Label>
                        <asp:Label runat="server" ID="lbl_20_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_20" class="textVerticalRechts"></asp:Label></asp:Panel>

                    <div class="beneden">11</div>
                    <div class="beneden">12</div>
                    <div class="beneden">13</div>
                    <div class="beneden">14</div>
                    <div class="beneden">15</div>
                    <div class="beneden">16</div>
                    <div class="beneden">17</div>
                    <div class="beneden">18</div>
                    <div class="beneden">19</div>
                    <div class="beneden">20</div>

                    <asp:Panel runat="server" class="boven" ID="clm_1">
                        <asp:Label runat="server" ID="lbl_1_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_1" class="textVerticalRechts"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_2">
                        <asp:Label runat="server" ID="lbl_2_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_2" class="textVerticalRechts"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_3">
                        <asp:Label runat="server" ID="lbl_3_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_3" class="textVerticalRechts"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_4">
                        <asp:Label runat="server" ID="lbl_4_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_4" class="textVerticalRechts"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_5">
                        <asp:Label runat="server" ID="lbl_5_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_5" class="textVerticalRechts"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_6">
                        <asp:Label runat="server" ID="lbl_6_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_6" class="textVerticalRechts"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_7">
                        <asp:Label runat="server" ID="lbl_7_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_7" class="textVerticalRechts"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_8">
                        <asp:Label runat="server" ID="lbl_8_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_8" class="textVerticalRechts"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_9">
                        <asp:Label runat="server" ID="lbl_9_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_9" class="textVerticalRechts"></asp:Label></asp:Panel>
                    <asp:Panel runat="server" class="boven" ID="clm_10">
                        <asp:Label runat="server" ID="lbl_Breedte_Rechts_Beneden" class="textBreedteRechtsBeneden"></asp:Label>
                        <asp:Label runat="server" ID="lbl_10_Prix" class="textVerticalRechtseuro"></asp:Label>
                        <asp:Label runat="server" ID="lbl_10" class="textVerticalRechts"></asp:Label></asp:Panel>

                    <div class="beneden">1</div>
                    <div class="beneden">2</div>
                    <div class="beneden">3</div>
                    <div class="beneden">4</div>
                    <div class="beneden">5</div>
                    <div class="beneden">6</div>
                    <div class="beneden">7</div>
                    <div class="beneden">8</div>
                    <div class="beneden">9</div>
                    <div class="beneden">10</div>
                </div>

                <div class="info-kolom">
                    <div class="infoKolom1" aria-orientation="vertical">
                        <asp:Button runat="server" Text="Producten" CssClass="btn_Producten"/>
                        <br /><br />
                        <asp:Label runat="server" CssClass="infoFabrikantLabel" >BAT= </asp:Label><br />
                        <asp:Label runat="server" CssClass="infoFabrikantLabel" >ITB= </asp:Label><br />
                        <asp:Label runat="server" CssClass="infoFabrikantLabel" >JTI = </asp:Label><br />
                        <asp:Label runat="server" CssClass="infoFabrikantLabel" >PMI= </asp:Label><br />
                        <asp:Button runat="server" Text="Niet Actief" CssClass="btn_NietActief" OnClick="btn_Activatie_Click"/><br />
                        <asp:Button runat="server" Text="20" CssClass="btn_20" OnClick="btn_20_Inhoud_Click"/><br />
                        <asp:Button runat="server" Text="21 - 46" CssClass="btn_21-46" OnClick="btn_21_46_Click"/><br />
                        <asp:Button runat="server" Text="47 - 60" CssClass="btn_47-60" OnClick="btn_47_60_Click"/><br />
                    </div>

                    <div class="infoKolom2" aria-orientation="vertical">
                        <asp:Button runat="server" Text="Assortimenten" CssClass="btn_Assortiment"/>
                        <asp:TextBox runat="server" CssClass="textPass"></asp:TextBox>
                        <asp:Label runat="server" ID="lbl_BAT" CssClass="infoFabrikantLabel"></asp:Label><br />
                        <asp:Label runat="server" ID="lbl_ITB" CssClass="infoFabrikantLabel"></asp:Label><br />
                        <asp:Label runat="server" ID="lbl_JTI" CssClass="infoFabrikantLabel"></asp:Label><br />
                        <asp:Label runat="server" ID="lbl_PMI" CssClass="infoFabrikantLabel"></asp:Label><br />
                        <asp:Label runat="server" ID="lbl_NietActief" CssClass="infoFabrikantLabel"></asp:Label><br />
                    </div>
                </div>
            </div>

            <div class="roww2" aria-orientation="horizontal">
                <div class="import-export" aria-orientation="horizontal">
                    <%--<input class="btn" type="file" name="file" />
                    <input type="submit" value="Upload" />--%>

                        <asp:FileUpload
                            class="btnf"
                            ID="btn_import"
                            runat="server"
                            Text="Import" />

                        <asp:Button
                            Text="Upload"
                            runat="server"
                            OnClick="Btn_Import_Click"
                            class="btnf" 
                            type="button"/>  
                </div>

                <div>
                      <asp:TextBox
                            runat="server"
                            ID="txtID"
                            class="searchText">
                      </asp:TextBox>
                </div>


                <div class="fabrikanten">
                    <asp:Button
                        ID="btn_BAT_Cc"
                        runat="server"
                        Text="BAT_C"
                        OnClick="btn_BAT_C"
                        class="btn" />

                    <asp:Button
                        ID="btn_BAT_Tt"
                        runat="server"
                        Text="BAT_T"
                        OnClick="btn_BAT_T"
                        class="btn" />

                    <asp:Button
                        ID="btn_ITB_Cc"
                        runat="server"
                        Text="ITB_C"
                        OnClick="btn_ITB_C"
                        class="btn" />

                    <asp:Button
                        ID="btn_ITB_Tt"
                        runat="server"
                        Text="ITB_T"
                        OnClick="btn_ITB_T"
                        class="btn" />

                    <asp:Button
                        ID="btn_JTI_Cc"
                        runat="server"
                        Text="JTI_C"
                        OnClick="btn_JTI_C"
                        class="btn" />

                    <asp:Button
                        ID="btn_JTI_Tt"
                        runat="server"
                        Text="JTI_T"
                        OnClick="btn_JTI_T"
                        class="btn" />

                    <asp:Button
                        ID="btn_PMI_Cc"
                        runat="server"
                        Text="PMI_C"
                        OnClick="btn_PMI_C"
                        class="btn" />
                </div>
            </div>

            <div class="row3">
                <div class="table-wrapper-scroll-y my-custom-scrollbar">
                    <asp:GridView ID="data_Ini" runat="server" class="sortTable" CssClass="display compact">
                    </asp:GridView>
                </div>

                <div class="table-wrapper-scroll-y my-custom-scrollbar">
                    <asp:GridView ID="data_Product" runat="server" class="sortTable" CssClass="display compact">
                    </asp:GridView>
                </div>

                <div class="table-wrapper-scroll-y my-custom-scrollbar">
                    <asp:GridView ID="data_Assortiment" runat="server" class="sortTable" CssClass="display compact">
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
<%--<script type="text/javascript">
    $(document).ready(function () {
            $('#<%=data_Product.ClientID%>').DataTable();
            $('#<%=data_Assortiment.ClientID%>').DataTable();
            $('#<%=data_Ini.ClientID%>').DataTable();
        })
</script>--%>
<link rel="stylesheet" href="~/CSS/Home.css" />

