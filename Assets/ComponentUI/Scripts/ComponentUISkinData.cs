using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ComponentUI.Base
{
    //TODO: Write an editor for this
    [CreateAssetMenu()]
    public class ComponentUISkinData : ScriptableObject
    {

        public Font defaultFont;
        public Font headerFont;
        public Font secondaryFont;
        public Color defaultFontColor;

        public Color defaultRed;
        public Color defaultGreen;
        public Color defaultLightBlue;
        public Color defaultDarkBlue;


        //The default to revert to
        public Sprite baseImage;
        public Color baseColor;

        public Sprite baseButtonSprite;

        public Color headerColor;
        public Sprite headerImage;

        public Color bodyColor;
        public Sprite bodyImage;

        public Color footerColor;
        public Sprite footerImage;

        public Color spaceColor;

        public ColorBlock tabActiveColors;
        public Color tabActiveTextcolor;

        public ColorBlock tabInactiveColors;
        public Color tabInactiveTextColor;

        public Color tabBackgroundColor;


        //Buttons
        public Sprite buttonSprite;
        public ColorBlock acceptButtonColors;
        public ColorBlock declineButtonColors;
        public ColorBlock warningButtonColors;
        public ColorBlock defaultButtonColors;

        public Color radialActionButtonDefaultBaseColor;
        public Color radialActionButtonDefaultTextColor;
        public Color radialActionButtonDefaultIconBackColor;
        public Color radialActionButtonDefaultIconColor;

        public Color radialActionButtonHoverBaseColor;
        public Color radialActionButtonHoverTextColor;
        public Color radialActionButtonHoverIconBackColor;
        public Color radialActionButtonHoverIconColor;

        public Color radialActionButtonDisabledBaseColor;
        public Color radialActionButtonDisabledTextColor;
        public Color radialActionButtonDisabledIconBackColor;
        public Color radialActionButtonDisabledIconColor;

        public Color progressBarSkinBackgroundColor;
        public Color progressBarProgressColor;
        public Color progressBarTextColor;

        public Color[] progressBarColors;



        public Color progressBarIconBackground;
        public Color progressBarIcon;
        public Color progressBarBackground;

        public Color iconBoxTextColor;


        public Sprite navbarBody;
        public Sprite navbarLeft;
        public Sprite navbarRight;

        public Sprite scrollSkinSprite;
        public Color scrollSkinColor;
        public Sprite scrollHandleSprite;
        public Color scrollHandleColor;

        public Color menuItemTextBackgroundColor;
        public Color menuItemControlBackgroundColor;

        public Sprite toggleBoxSkin;
        public Color toggleBoxSkinColor;
        public Sprite toggleBoxToggleSkin;
        public ColorBlock toggleBoxButtonColors;
        public Color toggleBoxToggleColor;

        public Sprite dropdownBoxLabelSkin;
        public ColorBlock dropdownBoxLabelColors;
        public Color dropdownBoxLabelTextColor;
        public Sprite dropdownBoxBackgroundSprite;
        public Color dropdownBoxBackgroundColor;

        public Sprite dropdownOptionSprite;
        public Color dropdownOptionTextColor;
        public ColorBlock dropdownOptionColors;

        public Sprite dropdownIcon;
        public Color dropdownIconColor;

        public Sprite inputSkin;
        public Color inputSkinColor;
        public Color inputTextColor;
        public Color inputSelectionColor;
        public Color inputCaretColor;


        public Color districtHeadeerBoxPurchasedMainColor;
        public Color districtHeadeerBoxPurchasedAsideColor;
        public Color districtHeadeerBoxUnlockedMainColor;
        public Color districtHeadeerBoxUnlockedAsideColor;
        public Color districtHeadeerBoxLockedMainColor;
        public Color districtHeadeerBoxLockedAsideColor;


        public Sprite districtInfoPanelHeader;
        public Sprite districtInfoPanelFooter;
        public Color districtInfoPanelMainColor;
        public Color districtInfoPanelSecondaryColor;
        public Color districtInfoPanelMainTextColor;
        public Color districtInfoPanelSecondaryTextColor;


        public Color dealerInfoHeaderColor;
        public Color dealerInfoBodyTextColor;
        public ColorBlock dealerInfoButtonColors;
        public Sprite dealerInfoHeaderSprite;
        public Sprite dealerInfoBottomLeftSprite;
        public Sprite dealerInfoBottomRightSprite;

        public ColorBlock listItemDefaultColors;


        public Color statModifierPositive;
        public Color statModifierPositiveSecondary;
        public Color statModifierNegative;
        public Color statModifierNegativeSecondary;

    }
}
